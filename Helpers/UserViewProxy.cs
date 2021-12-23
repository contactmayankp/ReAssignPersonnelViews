using Microsoft.Xrm.Sdk;

namespace Sdmsols.XTB.ReAssignPersonnelViews.Helpers
{
    public class UserViewProxy
    {
        #region Public Fields

        public Entity UserView;

        #endregion Public Fields

        #region Public Constructors

        public UserViewProxy(Entity userView)
        {
            UserView = userView;
        }

        #endregion Public Constructors


        public string Id => UserView.Id.ToString();
        public string Name => UserView["name"].ToString();

        public string EntityName => UserView["returnedtypecode"].ToString();
        

        #region Public Methods

        public override string ToString()
        {
            if (UserView != null)
            {
                if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(EntityName))
                {
                    return $"{Name} ({EntityName})";
                }
                return Id;
            }
            return base.ToString();
        }

        #endregion Public Methods
    }
}