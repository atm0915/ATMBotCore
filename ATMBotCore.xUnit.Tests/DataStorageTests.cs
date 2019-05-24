using System;
using ATMBotCore.Storage;
using ATMBotCore.Storage.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ATMBotCore.xUnit.Tests
{
    public class DataStorageTests
    {
        [Fact]
        public void StorageDefaultsToJson()
        {
            var storage = InversionOfControl.Provider.GetRequiredService<IDataStorage>();

            Assert.IsType<JsonStorage>(storage);
        }

        [Fact]
        public void InMemoryStorageTest()
        {
            const string expectedKey = "TEST";
            const string expectedResult = "I'm a unit test!";

            IDataStorage storage = new InMemoryStorage();

            storage.StoreObject(expectedKey, "I'm different.");
            storage.StoreObject(expectedKey, expectedResult);

            var actualResult = storage.RestoreObject<string>(expectedKey);

            Assert.Equal(expectedResult, actualResult);
            Assert.Throws<ArgumentException>(() => storage.RestoreObject<object>("FAKE-KEY"));
        }

        [Fact]
        public void JsonStorageTest()
        {
            const string expectedKey = "Testing/Test";
            const string expectedResult = "I'm a unit test!";

            IDataStorage storage = new JsonStorage();

            storage.StoreObject(expectedKey, "I'm different.");
            storage.StoreObject(expectedKey, expectedResult);

            var actualResult = storage.RestoreObject<string>(expectedKey);

            Assert.Equal(expectedResult, actualResult);
            Assert.Throws<ArgumentException>(() => storage.RestoreObject<object>("FAKE-KEY"));
        }
    }
}