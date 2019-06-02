using OpenVote.Shared;
using OpenVote.Shared.Organizations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace OpenVote.Forms.Models
{
    public class VoteViewModel : INotifyPropertyChanged
    {
        IOrganization organization;

        public IOrganization Organization
        {
            set
            {
                if (organization != value)
                {
                    organization = value;
                    OrganizationName = organization.Name;
                }
            }

            get
            {
                return organization;
            }
        }

        string organizationName;

        public string OrganizationName
        {
            set
            {
                if (organizationName != value)
                {
                    organizationName = value;
                    OnPropertyChanged("OrganizationName");
                }
            }

            get
            {
                return organizationName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
