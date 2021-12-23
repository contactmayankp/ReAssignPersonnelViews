using Microsoft.Xrm.Sdk;

namespace Sdmsols.XTB.ReAssignPersonnelViews.Helpers
{
    internal class UserTeamProxy
    {
        #region Public Fields

        public Entity UserOrTeamEntity;

        #endregion Public Fields

        #region Public Constructors

        public UserTeamProxy(Entity userOrTeamEntity)
        {
            UserOrTeamEntity = userOrTeamEntity;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Id => UserOrTeamEntity.Id.ToString();
        public string UserName => UserOrTeamEntity.Contains("fullname")? UserOrTeamEntity["fullname"].ToString():string.Empty;
        public string TeamName => UserOrTeamEntity.Contains("name") ? UserOrTeamEntity["name"].ToString() : string.Empty;


        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            if (UserOrTeamEntity != null)
            {
                if (!string.IsNullOrEmpty(UserName))
                {
                    return $"{UserName}  (USER)";
                }
                else if (!string.IsNullOrEmpty(TeamName))
                {
                    return $"{TeamName}  (TEAM)";
                }
                return Id;
            }
            return base.ToString();
        }

        #endregion Public Methods
    }
}