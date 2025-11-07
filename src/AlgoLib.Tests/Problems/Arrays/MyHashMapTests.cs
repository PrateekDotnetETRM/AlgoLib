using System.Linq;
using Xunit;
using FluentAssertions;
using AlgoLib.Core.Problems.Arrays;

namespace AlgoLib.Tests.Problems.Arrays
{
    public class MyHashMapTests
    {
        [Fact]
        public void Put_ShouldInsertAndRetrieveValue()
        {
            var map = new MyHashMap<string, int>();
            map.Put("apple", 10);

            map.TryGetValue("apple", out var value).Should().BeTrue();
            value.Should().Be(10);
        }

        [Fact]
        public void Put_ShouldUpdateExistingKey()
        {
            var map = new MyHashMap<string, int>();
            map.Put("apple", 10);
            map.Put("apple", 20);

            map.GetAll().Count().Should().Be(1);
            map.TryGetValue("apple", out var value).Should().BeTrue();
            value.Should().Be(20);
        }

        [Fact]
        public void Remove_ShouldDeleteKey()
        {
            var map = new MyHashMap<string, int>();
            map.Put("apple", 10);
            map.Remove("apple");

            map.TryGetValue("apple", out var value).Should().BeFalse();
        }

        [Fact]
        public void Get_ShouldThrowForMissingKey()
        {
            var map = new MyHashMap<string, int>();
            Action act = () => map.Get("missing");
            act.Should().Throw<ArgumentException>().WithMessage("*doesn't exists*");
        }

        [Fact]
        public void Linq_ShouldFilterValues()
        {
            var map = new MyHashMap<string, int>();
            map.Put("apple", 10);
            map.Put("banana", 20);
            map.Put("cherry", 30);

            var result = map.GetAll().Where(kvp => kvp.Value > 15).Select(kvp => kvp.Key).ToList();
            result.Should().Contain(new[] { "banana", "cherry" });
        }

        [Fact]
        public void Put_ShouldInsertAndRetrieveValue_Fast()
        {
            var map = new FastHashMap<string, int>();
            map.Put("apple", 10);

            map.TryGetValue("apple", out var value).Should().BeTrue();
            value.Should().Be(10);
        }

        [Fact]
        public void Put_ShouldUpdateExistingKey_Fast()
        {
            var map = new FastHashMap<string, int>();
            map.Put("apple", 10);
            map.Put("apple", 20);

            map.Count().Should().Be(1);
            map.TryGetValue("apple", out var value).Should().BeTrue();
            value.Should().Be(20);
        }

        [Fact]
        public void ContainsKey_ShouldReturnTrueForExistingKey()
        {
            var map = new FastHashMap<string, int>();
            map.Put("banana", 5);

            map.ContainsKey("banana").Should().BeTrue();
            map.ContainsKey("orange").Should().BeFalse();
        }

        [Fact]
        public void Remove_ShouldDeleteKey_Fast()
        {
            var map = new FastHashMap<string, int>();
            map.Put("apple", 10);
            map.Remove("apple");

            map.ContainsKey("apple").Should().BeFalse();
        }

        [Fact]
        public void Clear_ShouldRemoveAllItems()
        {
            var map = new FastHashMap<string, int>();
            map.Put("apple", 10);
            map.Put("banana", 20);

            map.Clear();
            map.Count().Should().Be(0);
        }

        [Fact]
        public void Linq_ShouldFilterValues_Fast()
        {
            var map = new FastHashMap<string, int>();
            map.Put("apple", 10);
            map.Put("banana", 20);
            map.Put("cherry", 30);

            var result = map.Where(kvp => kvp.Value > 15).Select(kvp => kvp.Key).ToList();
            result.Should().Contain(new[] { "banana", "cherry" });
        }
    }

}


