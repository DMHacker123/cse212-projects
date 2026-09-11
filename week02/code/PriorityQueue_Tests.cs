using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add several items with different priorities.
    // Expected Result: The item with the highest priority is dequeued first.
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Alice", 1);
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Charlie", 2);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Charlie", priorityQueue.Dequeue());
        Assert.AreEqual("Alice", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with the same priority.
    // Expected Result: Items with the same priority are dequeued
    // in the order they were added (FIFO).
    // Defect(s) Found: The Dequeue method originally used >= when comparing
    // priorities, causing the most recently added item with the same priority
    // to be removed first instead of preserving FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Alice", 5);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Charlie", 5);

        Assert.AreEqual("Alice", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Charlie", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add several items to the queue.
    // Expected Result: Items should remain in the order they were added because
    // Enqueue always adds the new item to the back of the queue.
    // Defect(s) Found: None.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Alice", 1);
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Charlie", 2);

        Assert.AreEqual(
            "[Alice (Pri:1), Bob (Pri:3), Charlie (Pri:2)]",
            priorityQueue.ToString()
        );
    }

    [TestMethod]
    // Scenario: Try to dequeue an item from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the
    // message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An InvalidOperationException should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format(
                    "Unexpected exception of type {0} caught: {1}",
                    e.GetType(),
                    e.Message
                )
            );
        }
    }
}

