//using Microsoft.Xrm.Sdk;

//namespace Sdmsols.XTB.ReAssignPersonnelViews.Helpers
//{
//    internal class UserProxy
//    {
//        #region Public Fields

//        public Entity User;

//        #endregion Public Fields

//        #region Public Constructors

//        public UserProxy(Entity userEntity)
//        {
//            User = userEntity;
//        }

//        #endregion Public Constructors

//        #region Public Properties

//        public string Id => User.Id.ToString();
//        public string FullName => User["fullname"].ToString();

//        #endregion Public Properties

//        #region Public Methods

//        public override string ToString()
//        {
//            return $"{User["fullname"]}";
//        }

//        #endregion Public Methods
//    }
//}