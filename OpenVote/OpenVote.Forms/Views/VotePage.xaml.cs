using OpenVote.Forms.Models;
using OpenVote.Shared;
using OpenVote.Shared.Organizations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenVote.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VotePage : ContentPage
	{
        public VotePage(object organization)
        {
            InitializeComponent();
            VoteViewModel model = (VoteViewModel)myLab.BindingContext;
            model.Organization = (IOrganization)organization;
        }
    }
}