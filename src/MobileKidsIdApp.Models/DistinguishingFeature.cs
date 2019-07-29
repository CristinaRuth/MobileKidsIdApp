﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class DistinguishingFeature : BaseTypes.BusinessBase<DistinguishingFeature>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }

        public static readonly PropertyInfo<FileReference> FileReferenceProperty = RegisterProperty<FileReference>(c => c.FileReference);
        public FileReference FileReference
        {
            get { return GetProperty(FileReferenceProperty); }
            private set { LoadProperty(FileReferenceProperty, value); }
        }

        protected void Child_Create(int id)
        {
            using (BypassPropertyChecks)
            {
                Id = id;
                FileReference = DataPortal.CreateChild<FileReference>();
            }
            base.Child_Create();
        }

        private void Child_Fetch(DataAccess.DataModels.DistinguishingFeature feature)
        {
            using (BypassPropertyChecks)
            {
                Id = feature.Id;
                Description = feature.Description;
                FileReference = DataPortal.FetchChild<FileReference>(feature.FileReference);
            }
        }

        private void Child_Insert(List<DataAccess.DataModels.DistinguishingFeature> list)
        {
            Child_Update(list);
        }

        private void Child_Update(List<DataAccess.DataModels.DistinguishingFeature> list)
        {
            using (BypassPropertyChecks)
            {

                var feature = new DataAccess.DataModels.DistinguishingFeature
                {
                    Id = Id,
                    Description = Description,
                    FileReference = new DataAccess.DataModels.FileReference()
                };
                DataPortal.UpdateChild(FileReference, feature.FileReference);
                list.Add(feature);
            }
        }

        private void Child_DeleteSelf()
        {
            // do nothing - if we don't re-add this item it won't exist
        }
    }
}
