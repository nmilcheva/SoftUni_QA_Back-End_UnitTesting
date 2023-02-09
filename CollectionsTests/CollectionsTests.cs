namespace CollectionsTests
{
    public class Tests
    {
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var nums = new Collections.Collection<int>();
            Assert.That(nums.ToString(),Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collections.Collection<int>();
            nums.Add(1);
            var expected = 1;
            var actual = nums.Count;
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collections.Collection<int>(5, 10, 15);
            Assert.That(nums.ToString, Is.EqualTo("[5, 10, 15]"));
        }

        [Test]
        public void Test_Collection_Add()
        {
            var nums = new Collections.Collection<int>();
            nums.Add(1);
            Assert.That(nums.ToString(), Is.EqualTo("[1]"));
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var nums = new Collections.Collection<int>();
            nums.Add(1);
            nums.Add(2);
            nums.Add(3);
            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3]"));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var nums = new Collections.Collection<int>();
            var newNums = Enumerable.Range(1, 100).ToArray();
            nums.AddRange(newNums);
            
            Assert.That(nums.Count, Is.EqualTo(100));
        }
        [Test]
        public void Test_Collection_GetByIndex()
        {
            var names = new Collections.Collection<string>("Peter", "Maria");
            var firstName = names[0];
            var secondName = names[1];
            Assert.That(firstName, Is.EqualTo("Peter"));
            Assert.That(secondName, Is.EqualTo("Maria"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collections.Collection<string>("Peter", "Maria");
            
            Assert.That(()=> { var wrongIndex = names[-1]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var wrongIndex = names[2]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var wrongIndex = names[500]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var names = new Collections.Collection<string>("Peter", "Maria");
            //var firstName = names[0];
            //var secondName = names[1];
            //firstName = "John";
            names[0] = "John";
            names[1] = "Elsa";
            Assert.That(() => { var wrongIndex = names[-1]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var wrongIndex = names[2]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var wrongIndex = names[500]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var names = new Collections.Collection<string>("Peter", "Maria");
            //var firstName = names[0];
            //var secondName = names[1];
            //firstName = "John";
            names[0] = "John";
            names[1] = "Elsa";
            Assert.That(names[0].ToString(), Is.EqualTo("John"));
            Assert.That(names[1].ToString(), Is.EqualTo("Elsa"));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collections.Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }



        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var nums = new Collections.Collection<int>(5, 10, 15);
            nums.RemoveAt(0);
            Assert.That(nums.ToString(), Is.EqualTo("[10, 15]"));
        }
        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var nums = new Collections.Collection<int>(5, 10, 15);
            nums.RemoveAt(2);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 10]"));
        }
        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var nums = new Collections.Collection<int>(5, 10, 15);
            nums.InsertAt(0,4);
            Assert.That(nums.ToString(), Is.EqualTo("[4, 5, 10, 15]"));
        }
        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var nums = new Collections.Collection<int>(5, 10, 15);
            nums.InsertAt(3, 20);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15, 20]"));
        }
        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var nums = new Collections.Collection<int>(1, 2, 3, 4);
            //int dummy = nums[1];
            //nums[1] = nums[2];
            //nums[2] = dummy;
            nums.Exchange(1, 2);
            Assert.That(nums.ToString(), Is.EqualTo("[1, 3, 2, 4]"));

        }
        public void Test_Collection_ExchangeFirstLast()
        {
            var nums = new Collections.Collection<int>(1, 2, 3, 4);
            int dummy = nums[0];
            nums[0] = nums[nums.Count-1];
            nums[nums.Count-1] = dummy;
            Assert.That(nums.ToString(), Is.EqualTo("[4, 3, 2, 1]"));

        }

        [Test]
        public void Test_Collection_Clear()
        {
            var nums = new Collections.Collection<int>();
            nums.Clear();
            Assert.That(nums.Equals(null), Is.False);
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var nums = new Collections.Collection<int>(5, 6);
            Assert.That(nums.Count, Is.EqualTo(2));
            Assert.That(nums.Capacity, Is.GreaterThan(nums.Count));
        }
    }
}