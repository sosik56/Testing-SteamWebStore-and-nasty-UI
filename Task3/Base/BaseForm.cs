using Task3.Utility;

namespace Task3.Base
{
    abstract public class BaseForm
    {
        private BaseElement _baseElement;
        private string _namePage;
        public BaseForm(BaseElement elem, string namePage)
        {
            _baseElement = elem;
            _namePage = namePage;
        }
        
        public bool IsPageOpen()
        {
            LogUtils.MakeSystemLog($"{_namePage} is {_baseElement.IsVisible().ToString()} Opened");
            return _baseElement.IsVisible();
        }
    }
}
