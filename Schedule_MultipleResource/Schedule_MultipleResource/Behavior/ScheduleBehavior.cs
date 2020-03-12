using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Schedule_MultipleResource
{
    class ScheduleBehavior:Behavior<ContentPage>
    {
        SfSchedule Schedule;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            Schedule = bindable.FindByName<SfSchedule>("Schedule");
        }
    }
}
