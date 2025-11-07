using FluentAssertions;
using Xunit;

namespace AlgoLib.Tests.Problems.Arrays
{
    using AlgoLib.Core.Problems.Arrays;
    using FluentAssertions;
    using System;
    using Xunit;

    public class MyHashMapTests
    {
        [Fact]
        public void PutAndGet_ShouldStoreAndRetrieveValue()
        {
            var map = new MyHashMap();
            map.Put(1, 100);

            map.Get(1).Should().Be(100);
        }

        [Fact]
        public void Get_ShouldReturnMinusOneForMissingKey()
        {
            var map = new MyHashMap();
            map.Get(999).Should().Be(-1);
        }

        [Fact]
        public void Put_ShouldOverwriteExistingValue()
        {
            var map = new MyHashMap();
            map.Put(1, 100);
            map.Put(1, 200);

            map.Get(1).Should().Be(200);
        }

        [Fact]
        public void Remove_ShouldDeleteKey()
        {
            var map = new MyHashMap();
            map.Put(1, 100);
            map.Remove(1);

            map.Get(1).Should().Be(-1);
        }

        [Fact]
        public void Remove_ShouldNotThrowForMissingKey()
        {
            var map = new MyHashMap();
            Action act = () => map.Remove(999);

            act.Should().NotThrow();
        }

        [Fact]
        public void Put_ShouldHandleCollisions()
        {
            var map = new MyHashMap();

            // These keys should collide if hash function is simple
            int key1 = 1;
            int key2 = key1 + (int)Math.Pow(2, 4); // Try to force collision

            map.Put(key1, 100);
            map.Put(key2, 200);

            map.Get(key1).Should().Be(100);
            map.Get(key2).Should().Be(200);
        }

        [Fact]
        public void Resize_ShouldDoubleCapacityAndPreserveData()
        {
            var map = new MyHashMap();

            // Insert enough items to trigger resize
            for (int i = 0; i < 10; i++)
            {
                map.Put(i, i * 10);
            }

            for (int i = 0; i < 10; i++)
            {
                map.Get(i).Should().Be(i * 10);
            }
        }

        [Fact]
        public void Resize_ShouldThrowOnOverflow()
        {
            var map = new MyHashMap();

            // Manually set capacity near max
            var capacityField = typeof(MyHashMap).GetField("capacity", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            capacityField.SetValue(map, uint.MaxValue >> 1);

            var countField = typeof(MyHashMap).GetField("count", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            countField.SetValue(map, uint.MaxValue >> 1);

            Action act = () => map.Put(999, 999);

            act.Should().Throw<InvalidOperationException>()
               .WithMessage("Cannot resize: capacity overflow or exceeds maximum allowed.");
        }
    }
}
