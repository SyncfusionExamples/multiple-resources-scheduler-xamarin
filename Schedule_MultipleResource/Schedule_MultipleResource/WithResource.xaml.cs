using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule_MultipleResource
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WithResource : Button
	{
		public WithResource ()
		{
			InitializeComponent ();
		}
	}
}