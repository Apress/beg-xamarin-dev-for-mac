using System;
using System.Threading.Tasks;
using CoreGraphics;
using UIKit;
using Users.MobileClient.Models;
using Users.MobileClient.TableSources;

namespace Users.MobileClient
{
    public partial class UsersListViewController : UIViewController
    {
        private UITableView usersTable;

        public UsersListViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            await AddUsersTable();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            usersTable?.ReloadData();
        }

        private async Task AddUsersTable()
        {                        
            var usersTableSource = new UsersTableSource()
            {
                ParentViewController = this,
                UsersRepository = await UsersRepository.GetInstance()
            };

            usersTable = new UITableView(GetFrameWithVerticalMargin(20))
            {
                Source = usersTableSource
            };

            Add(usersTable);
        }

        private CGRect GetFrameWithVerticalMargin(nfloat offset)
        {
            var rect = View.Frame;

            rect.Y = offset;
            rect.Height -= offset;

            return rect;
        }
    }
}