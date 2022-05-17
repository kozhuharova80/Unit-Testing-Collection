using Collections;
using NUnit.Framework;
using System;
using System.Linq;


namespace Collection.Test
{
    public class CollectionTest
    {
        

        [Test]
        public void Test_EmptyConstructon()
        {
            //Arange
            var nums = new Collection<int>();

            //Assert
            Assert.AreEqual(0, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
            Assert.That(nums.ToString(), Is.EqualTo("[]"));          

        }
        [Test]
        public void Test_ConstructorSingleItem()
        {
            //Arange
            var nums = new Collection<int>(5);

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));

        }
        [Test]
        public void Test_CollectionAdd()
        {
            //Arange
            var nums = new Collection<int>(5);

            //Act
            nums.Add(1);

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[5, 1]"));

        }
        [Test]
        public void Test_CollectionAddRange()
        {
            //Arange
            var nums = new Collection<int>();

            //Act
            var newNums = Enumerable.Range(20, 30).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            
            //Assert
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.AreEqual(nums[0], 20);
                 
            
        }
        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            //Arange
            var nums = new Collection<int>();

            //Act
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }
        [Test]
        public void Test_CollectionGetByIndex()
        {
            // Arrange
            string[] names = { "Peter", "Maria", "Dani", "Ivo" };

            // Act 
            int i = 0;
            int count = 0;
            foreach (string element in names)
            {

                names[i++] = element.ToString();
                if (count !=0)
                {
                    count++;
                }
            }
           
            // Assert
            Assert.That(names[0], Does.Contain("Peter"));
            for (int j = 0; j < count; j++)
            {
               Assert.That(names[j], Does.Not.Contain("Ivan"));
            }
            Assert.AreEqual(names[1], "Maria");
            Assert.That(names[2], Is.EqualTo("Dani"));
            
        }
        [Test]
        public void Test_CollectionGetByInvalidIndex()
        {
            //Arrange
            var names = new Collection<string>("Bob", "Joe", "", "");

            //Assert
            Assert.That(() => { var name = names[-1]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[4]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.AreEqual(4, names.Count);

            //Act
            names[2] = "Dan";
            names[3] = "Ran";

            //Assert
            Assert.That(names[2], Is.EqualTo("Dan"));
            Assert.That(names[3], Is.EqualTo("Ran"));
            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe, Dan, Ran]"));
        }
        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            //Arrange
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);

            //Act
            string nestedToString = nested.ToString();            

            //Assert
            Assert.That(nestedToString, Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));

        }
        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            //Arrange
            const int itemsCount = 1000000;
            var nums = new Collection<int>();

            //Act
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            //Assert
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);

            //Act
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);

            //Assert
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }
        [Test]
        public void Test_CollectionExchange()
        {
            //Arange
            var nums = new Collection<int>(5, 6, 7);

            //Act
            nums.Add(1);

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[5, 6, 7, 1]"));

            //Act
            nums.Exchange(0, 3);
            Assert.AreNotEqual(nums.ToString(), "[5, 6, 7, 1]");
            Assert.AreEqual(nums.ToString(), "[1, 6, 7, 5]");

        }
        [Test]
        public void Test_CollectionInsertAt()
        {
            //Arange
            var nums = new Collection<int>();

            //Act
            int num = 10;
            int count = 0;
            for (int i = 0; i <= 5; i++)
            {               
                nums.InsertAt(i, num);
                num = num + 5;
                count++;
            }               

            //Assert
            Assert.That(nums.Count, Is.EqualTo(count));
            int verifyNum = 10;
            for (int j= 0; j <= 5; j++)
            {
                Assert.AreEqual(nums[j], verifyNum);
                verifyNum = verifyNum + 5;              
            }       
        }
        [Test]
        public void Test_CollectionRemoveAt()
        {
            //Arange
            var nums = new Collection<int>();

            //Act
            for (int i = 0; i <= 5; i++)
            {
                nums.Add(i);
            }

            //Assert           
            Assert.That(nums.ToString(), Is.EqualTo("[0, 1, 2, 3, 4, 5]"));

            //Act
            nums.RemoveAt(0);
            nums.RemoveAt(2);

            //Assert           
            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 4, 5]"));           

        }
    }
}