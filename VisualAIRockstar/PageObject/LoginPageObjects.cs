namespace HackathonRockstar.PageObject
{
    public class LoginPageObjects
    {
        #region Elements

        public const string LogoLinkCssSelector = "div.logo-w > a > img";
        public const string LoginFormHeaderCssSelector = "h4.auth-header";
        public const string RememberMeCheckBoxCssSelector = "input.form-check-input";
        public const string LoginButtonCssSelector = "button#log-in";
        public const string UserIconCssSelector = "div.os-icon-user-male-circle";
        public const string PasswordIconCssSelector = "div.os-icon-fingerprint";
        public const string OpenIdLoginCssSelector = "div.buttons-w > div:nth-child(3) > a:nth-child({0}) > img";
        public const string OpenIdLoginV2CssSelector = "div.buttons-w > div:nth-child(3) > span:nth-child({0}) > img";
        public const string LoginFormLabelXPath = "//label[text()='{0}']";
        public const string LoginFormTextBoxXPath = "//label[text()='{0}']/../input";
        public const string ErrorMessageCssSelector = "div.auth-box-w > div:nth-child(4)";

        #endregion
    }
}
