using NUnit.Framework;
using System;
using TermProject2;

namespace TermProject2.Tests
{
    [TestFixture]
    public class StackTests
    {
        // Test Push method with valid inputs
        [Test]
        public void Push_ValidItem_ItemIsAdded()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Push(10);

            // Assert
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Push_MultipleItems_AllItemsAreAdded()
        {
            // Arrange
            var stack = new Stack<string>();

            // Act
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            // Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Push_NullItem_ThrowsArgumentNullException()
        {
            // Arrange
            var stack = new Stack<string>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }

        // Test Pop method
        [Test]
        public void Pop_StackWithOneItem_ReturnsItemAndDecrementsCount()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(42);

            // Act
            var result = stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo(42));
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_StackWithMultipleItems_ReturnsLastItemFirst()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            // Act
            var result1 = stack.Pop();
            var result2 = stack.Pop();
            var result3 = stack.Pop();

            // Assert
            Assert.That(result1, Is.EqualTo("Third"));
            Assert.That(result2, Is.EqualTo("Second"));
            Assert.That(result3, Is.EqualTo("First"));
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Pop_AfterPoppingAllItems_ThrowsInvalidOperationException()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Pop();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        // Test Peek method
        [Test]
        public void Peek_StackWithOneItem_ReturnsItemWithoutRemovingIt()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(100);

            // Act
            var result = stack.Peek();

            // Assert
            Assert.That(result, Is.EqualTo(100));
            Assert.That(stack.Count, Is.EqualTo(1)); // Item should still be there
        }

        [Test]
        public void Peek_StackWithMultipleItems_ReturnsLastItem()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            // Act
            var result = stack.Peek();

            // Assert
            Assert.That(result, Is.EqualTo("Third"));
            Assert.That(stack.Count, Is.EqualTo(3)); // All items should still be there
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Peek_CalledMultipleTimes_ReturnsSameItem()
        {
            // Arrange
            var stack = new Stack<double>();
            stack.Push(3.14);

            // Act
            var result1 = stack.Peek();
            var result2 = stack.Peek();
            var result3 = stack.Peek();

            // Assert
            Assert.That(result1, Is.EqualTo(3.14));
            Assert.That(result2, Is.EqualTo(3.14));
            Assert.That(result3, Is.EqualTo(3.14));
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        // Test Count property
        [Test]
        public void Count_NewStack_ReturnsZero()
        {
            // Arrange
            var stack = new Stack<int>();

            // Assert
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_AfterPushAndPop_ReturnsCorrectValue()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.That(stack.Count, Is.EqualTo(3));

            stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(2));

            stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(1));

            stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        // Test LIFO (Last In First Out) behavior
        [Test]
        public void Stack_FollowsLIFOPrinciple()
        {
            // Arrange
            var stack = new Stack<int>();
            
            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // Assert - items should come out in reverse order
            Assert.That(stack.Pop(), Is.EqualTo(5));
            Assert.That(stack.Pop(), Is.EqualTo(4));
            Assert.That(stack.Pop(), Is.EqualTo(3));
            Assert.That(stack.Pop(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(1));
        }

        // Test with different data types
        [Test]
        public void Stack_WorksWithDifferentTypes_IntType()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Push(10);
            stack.Push(20);

            // Assert
            Assert.That(stack.Pop(), Is.EqualTo(20));
            Assert.That(stack.Pop(), Is.EqualTo(10));
        }

        [Test]
        public void Stack_WorksWithDifferentTypes_StringType()
        {
            // Arrange
            var stack = new Stack<string>();

            // Act
            stack.Push("Hello");
            stack.Push("World");

            // Assert
            Assert.That(stack.Pop(), Is.EqualTo("World"));
            Assert.That(stack.Pop(), Is.EqualTo("Hello"));
        }

        [Test]
        public void Stack_WorksWithDifferentTypes_CustomObjectType()
        {
            // Arrange
            var stack = new Stack<object>();
            var obj1 = new object();
            var obj2 = new object();

            // Act
            stack.Push(obj1);
            stack.Push(obj2);

            // Assert
            Assert.That(stack.Pop(), Is.SameAs(obj2));
            Assert.That(stack.Pop(), Is.SameAs(obj1));
        }
    }
}
