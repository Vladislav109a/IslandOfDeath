namespace PixelCrew.Model.Data.Properties
{
    public abstract class PrefsPersistemProperty<TPropertyType> : PersistemProperty<TPropertyType>
    {
        protected string Key;
        protected PrefsPersistemProperty(TPropertyType defaultValue, string key) : base(defaultValue)
        {
            Key = key;
        }
    }
}
