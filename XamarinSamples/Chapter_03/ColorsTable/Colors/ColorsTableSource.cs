﻿using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace ColorsTable.Colors
{
    public class ColorsTableSource : UITableViewSource
    {
        public List<Color> Items { get; private set; } = ColorsHelper.GetColors();

        const string cellId = "ColorCell";

		public UIViewController ParentViewController { get; private set; }

		public ColorsTableSource(UIViewController viewController)
		{
		    ParentViewController = viewController;
		}

        public override UITableViewCell GetCell(
            UITableView tableView, NSIndexPath indexPath)
        {
            // Get item to display
            var item = Items[indexPath.Row];

            // Try to reuse a cell before creating the new one
            var cell = tableView.DequeueReusableCell(cellId)
                                ?? new UITableViewCell(UITableViewCellStyle.Default, cellId);

            // Configure cell properties
            cell.TextLabel.Text = item.Name;
            cell.TextLabel.TextColor = item.Value;

            if (cell.DetailTextLabel != null)
            {
                cell.DetailTextLabel.Text = item.Value.ToString();
            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Count;
        }

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
		    if (ParentViewController != null)
		    {
		        DisplayColorInfo(tableView, indexPath);
		    }
		    else
		    {
		        base.RowSelected(tableView, indexPath);
		    }
		}

        public override void CommitEditingStyle(
            UITableView tableView,
            UITableViewCellEditingStyle editingStyle,
            NSIndexPath indexPath)
        {
            if (editingStyle == UITableViewCellEditingStyle.Delete)
            {
                Items.RemoveAt(indexPath.Row);
                tableView.DeleteRows(
                    new NSIndexPath[] { indexPath },
                    UITableViewRowAnimation.Automatic);
            }
        }

		public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
		{
		    var itemToDelete = Items[indexPath.Row];

		    return itemToDelete.Name != "Magenta";
		}

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var removeButton = UITableViewRowAction.Create(
                    UITableViewRowActionStyle.Destructive,
                    "Remove",
                    delegate
                    {
                        Items.RemoveAt(indexPath.Row);
                        tableView.DeleteRows(
                            new NSIndexPath[] { indexPath },
                            UITableViewRowAnimation.Middle);
                    });

            var markItemButton = UITableViewRowAction.Create(
                    UITableViewRowActionStyle.Normal,
                    "Mark",
                    delegate
                    {
                        tableView.CellAt(indexPath).BackgroundColor =
                            UIColor.FromRGBA(0, 255, 0, 35);
                    });

            return new UITableViewRowAction[] { removeButton, markItemButton };
        }

		private void DisplayColorInfo(UITableView tableView, NSIndexPath indexPath)
		{
			var selectedItem = Items[indexPath.Row];

			var alertController = UIAlertController.Create(
		        selectedItem.Name, selectedItem.Value.ToString(), 
		        UIAlertControllerStyle.Alert);
		    
			alertController.AddAction(UIAlertAction.Create(
		        "OK", UIAlertActionStyle.Default, null));

			ParentViewController.PresentViewController(
				alertController, 
                true, 
                () => { tableView.DeselectRow(indexPath, true); });
		}
    }
}
