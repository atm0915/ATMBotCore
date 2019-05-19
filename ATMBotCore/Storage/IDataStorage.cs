namespace ATMBotCore.Storage
{
    public interface IDataStorage
    {
        void StoreObject(string key, object obj);

        T RestoreObject<T>(string key);
    }
}