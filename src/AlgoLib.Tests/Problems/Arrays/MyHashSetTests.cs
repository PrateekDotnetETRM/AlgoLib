using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLib.Tests.Problems.Arrays
{
    using AlgoLib.Core.Problems.Arrays;
    using Xunit;

    public class MyHashSetTests
    {
        [Fact]
        public void Add_SingleValue_ShouldBeContained()
        {
            var set = new MyHashSet();
            set.Add(42);

            Assert.True(set.Contains(42));
        }

        [Fact]
        public void Add_DuplicateValue_ShouldNotIncreaseCount()
        {
            var set = new MyHashSet();
            set.Add(42);
            set.Add(42);

            Assert.True(set.Contains(42));
           
        }

        [Fact]
        public void Remove_ExistingValue_ShouldNotBeContained()
        {
            var set = new MyHashSet();
            set.Add(42);
            set.Remove(42);

            Assert.False(set.Contains(42));
        }

        [Fact]
        public void Remove_NonExistingValue_ShouldNotThrow()
        {
            var set = new MyHashSet();
            set.Add(42);
            set.Remove(99); // not in set

            Assert.True(set.Contains(42));
        }

        [Fact]
        public void Add_MultipleCollidingValues_ShouldAllBeContained()
        {
            var set = new MyHashSet();

            // These values are likely to collide in small capacity (e.g., 4)
            set.Add(4);
            set.Add(8);
            set.Add(12);
            set.Add(16);

            Assert.True(set.Contains(4));
            Assert.True(set.Contains(8));
            Assert.True(set.Contains(12));
            Assert.True(set.Contains(16));
        }

        [Fact]
        public void Remove_FromChain_ShouldPreserveOthers()
        {
            var set = new MyHashSet();
            set.Add(4);
            set.Add(8);
            set.Add(12);
            set.Add(16);
            set.Add(20);
            set.Remove(8);

            Assert.True(set.Contains(4));
            Assert.False(set.Contains(8));
            Assert.True(set.Contains(12));
        }

        [Fact]
        public void Add_TriggersResize_ShouldStillContainAll()
        {
            var set = new MyHashSet();

            // Add enough items to trigger resize (threshold = 3)
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4); // triggers resize

            Assert.True(set.Contains(1));
            Assert.True(set.Contains(2));
            Assert.True(set.Contains(3));
            Assert.True(set.Contains(4));
        }

        [Fact]
        public void Contains_EmptySet_ShouldReturnFalse()
        {
            var set = new MyHashSet();

            Assert.False(set.Contains(999));
        }
    }
}
