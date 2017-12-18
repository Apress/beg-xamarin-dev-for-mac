using System;
using System.Diagnostics;
using ClockKit;
using Foundation;

namespace HelloWatchKit.WatchExtension
{
    [Register("ComplicationController")]
    public class ComplicationController : CLKComplicationDataSource
    {
        protected ComplicationController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic
        }

        #region Timeline Configuration

        public override void GetSupportedTimeTravelDirections(CLKComplication complication, Action<CLKComplicationTimeTravelDirections> handler)
        {
            handler(CLKComplicationTimeTravelDirections.None);
        }

        public override void GetTimelineStartDate(CLKComplication complication, Action<NSDate> handler)
        {
            handler(null);
        }

        public override void GetTimelineEndDate(CLKComplication complication, Action<NSDate> handler)
        {
            handler(null);
        }

        public override void GetPrivacyBehavior(CLKComplication complication, Action<CLKComplicationPrivacyBehavior> handler)
        {            
            handler(CLKComplicationPrivacyBehavior.ShowOnLockScreen);
        }

        public override void RequestedUpdateBudgetExhausted()
        {
            Debug.WriteLine("RequestedUpdateBudgetExhausted");

            base.RequestedUpdateBudgetExhausted();
        }

        #endregion

        #region Timeline Population

        public override void GetCurrentTimelineEntry(CLKComplication complication, Action<CLKComplicationTimelineEntry> handler)
        {
            // Call the handler with the current timeline entry
            var timelineEntry = CreateComplicationEntry(complication.Family, ComplicationHelper.Answer);

            handler(timelineEntry);
        }

        public override void GetTimelineEntriesBeforeDate(CLKComplication complication, NSDate beforeDate, nuint limit, Action<CLKComplicationTimelineEntry[]> handler)
        {
            // Call the handler with the timeline entries prior to the given date
            handler(null);
        }

        public override void GetTimelineEntriesAfterDate(CLKComplication complication, NSDate afterDate, nuint limit, Action<CLKComplicationTimelineEntry[]> handler)
        {
            // Call the handler with the timeline entries after to the given date
            handler(null);
        }

        #endregion

        #region Placeholder Templates

        public override void GetPlaceholderTemplate(CLKComplication complication, Action<CLKComplicationTemplate> handler)
        {
            var template = CreateComplicationTemplate(complication.Family, "Sample text");

            handler(template);
        }

        public override void GetLocalizableSampleTemplate(CLKComplication complication, Action<CLKComplicationTemplate> handler)
        {
            var template = CreateComplicationTemplate(complication.Family, "Sample text");

            handler(template);
        }

        #endregion

        #region Helper methods

        private CLKComplicationTemplate CreateComplicationTemplate(CLKComplicationFamily complicationFamily, string complicationText)
        {
            CLKComplicationTemplate template = null;

            switch (complicationFamily)
            {
                case CLKComplicationFamily.ModularSmall:
                    template = new CLKComplicationTemplateModularSmallRingText()
                    {
                        TextProvider = CLKSimpleTextProvider.FromText(complicationText),
                        FillFraction = 0.75f,
                        RingStyle = CLKComplicationRingStyle.Open
                    };
                    break;

                case CLKComplicationFamily.ModularLarge:
                    template = new CLKComplicationTemplateModularLargeStandardBody()
                    {
                        HeaderTextProvider = CLKSimpleTextProvider.FromText("My Complication"),
                        Body1TextProvider = CLKSimpleTextProvider.FromText(complicationText),
                        Body2TextProvider = CLKTimeTextProvider.FromDate(NSDate.Now)
                    };
                    break;
            }

            return template;
        }

        private CLKComplicationTimelineEntry CreateComplicationEntry(CLKComplicationFamily complicationFamily, string complicationText)
        {
            var template = CreateComplicationTemplate(complicationFamily, complicationText);

            if (template != null)
            {
                return CLKComplicationTimelineEntry.Create(NSDate.Now, template);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}

