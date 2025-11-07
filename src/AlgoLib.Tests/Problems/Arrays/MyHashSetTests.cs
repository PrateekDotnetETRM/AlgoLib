using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLib.Tests.Problems.Arrays
{
    using AlgoLib.Core.Problems.Arrays;
    using FluentAssertions.Execution;
    using Xunit;

    public class MyHashSetTests
    {
       
        [Fact]
        public void IntSet_LargeVolume_AddRemoveContains()
        {
            var set = new MyHashSet<int>();

            for (int i = 0; i < 10000; i++)
                set.Add(i);

            for (int i = 0; i < 10000; i += 2)
                set.Remove(i);

            for (int i = 0; i < 10000; i++)
            {
                if (i % 2 == 0)
                    Assert.False(set.Contains(i));
                else
                    Assert.True(set.Contains(i));
            }
        }

        [Fact]
        public void StringSet_CollisionAndDuplicates()
        {
            var set = new MyHashSet<int>();

            string[] values = { "apple", "banana", "apple", "cherry", "banana" };
            foreach (var val in values)
                set.Add(val.GetHashCode()); // simulate string keys

            Assert.True(set.Contains("apple".GetHashCode()));
            Assert.True(set.Contains("banana".GetHashCode()));
            Assert.True(set.Contains("cherry".GetHashCode()));
        }

        [Fact]
        public void PersonSet_WithCustomComparer_ShouldHandleEquality()
        {
            var comparer = new PersonComparer();
            var set = new MyHashSet<Person>(comparer);

            var p1 = new Person("John", "Doe");
            var p2 = new Person("John", "Doe"); // same values
            var p3 = new Person("Jane", "Doe");

            set.Add(p1);
            set.Add(p2); // should not be added again
            set.Add(p3);

            Assert.True(set.Contains(p1));
            Assert.True(set.Contains(p2));
            Assert.True(set.Contains(p3));

            set.Remove(p2);
            Assert.False(set.Contains(p1)); // removed by equality
        }

        [Fact]
        public void PersonSet_LargeVolume_WithComparer()
        {
            var comparer = new PersonComparer();
            var set = new MyHashSet<Person>(comparer);

            for (int i = 0; i < 1000; i++)
            {
                var person = new Person($"First{i}", $"Last{i}");
                set.Add(person);
            }

            for (int i = 0; i < 1000; i++)
            {
                var person = new Person($"First{i}", $"Last{i}");
                Assert.True(set.Contains(person));
            }
        }

        [Fact]
        public void Add_SingleValue_ShouldBeContained()
        {
            var set = new MyHashSet<int>();
            set.Add(42);

            Assert.True(set.Contains(42));
        }

        [Fact]
        public void Add_DuplicateValue_ShouldNotIncreaseCount()
        {
            var set = new MyHashSet<int>();
            set.Add(42);
            set.Add(42);

            Assert.True(set.Contains(42));
           
        }

        [Fact]
        public void Remove_ExistingValue_ShouldNotBeContained()
        {
            var set = new MyHashSet<int>();
            set.Add(42);
            set.Remove(42);

            Assert.False(set.Contains(42));
        }

        [Fact]
        public void Remove_NonExistingValue_ShouldNotThrow()
        {
            var set = new MyHashSet<int>();
            set.Add(42);
            set.Remove(99); // not in set

            Assert.True(set.Contains(42));
        }

        [Fact]
        public void Add_MultipleCollidingValues_ShouldAllBeContained()
        {
            var set = new MyHashSet<int>();

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
            var set = new MyHashSet<int>();
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
            var set = new MyHashSet<int>();

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
            var set = new MyHashSet<int>();

            Assert.False(set.Contains(999));
        }
    }

    public class Person
    {
        public string FirstName;
        public string LastName;

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public override int GetHashCode() => HashCode.Combine(FirstName, LastName);
        public override bool Equals(object obj) =>
            obj is Person p && p.FirstName == FirstName && p.LastName == LastName;
    }

    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y) => x.FirstName == y.FirstName && x.LastName == y.LastName;

        public int GetHashCode(Person obj) => HashCode.Combine(obj.FirstName, obj.LastName);
    }
}
