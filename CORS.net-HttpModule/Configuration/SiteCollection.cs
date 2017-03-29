using System.Configuration;

namespace CORS.net_HttpModule.Configuration
{
    public class Sites
        : ConfigurationElementCollection
    {
        public Site this[int index]
        {
            get
            {
                return base.BaseGet(index) as Site;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new Site this[string responseString]
        {
            get { return (Site)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new Site();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((Site)element).Url;
        }
    }
}
