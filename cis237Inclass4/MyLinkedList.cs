using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass4
{
    class MyLinkedList
    {
        //Private variable to hold the current position of where we are in the linked list
        private Node current;

        //Private variable to hold the last position of the linked list
        private Node last;

        //A public property that will point to the head node. (The first one in the list)
        public Node Head
        {
            get;
            set;
        }

        //Constructor. It will set the Head to null because there is nothing in the list yet.
        public MyLinkedList()
        {
            Head = null;
        }

        public void Add(string Content)
        {
            //Make a new node to add to the linked list
            Node node = new Node();
            //Set the data to the passed in content
            node.Data = Content;

            //This will add the first element to our list
            if (Head == null)
            {
                Head = node;
            }
            //Not the first node, so set the new node to the current node's next variable
            else
            {
                last.Next = node;
                
            }
            //Move down the list. Set the current to the next node we added.
            last = node;
        }

        public bool Delete(int Position)
        {
            //Set current to Head. Need to walk through it from the beginning
            current = Head;

            //If the position is the very first node in the list
            if (Position == 1)
            {
                //Set the head to the next node in the list. This will be the second one
                Head = current.Next;
                //Delete the Current.Next pointer so there is no reference from current to
                //another node
                current.Next = null;
                //current = null; because we want the garbage collector to come pick it up.
                current = null;
                //it was successful so, return true
                return true;
            }

            //check to make sure that at least a positive number was entered
            //should also chack to make sure that the position is less than the
            //size of the array so that we areen't looking for something that doesn't
            //exist. Adding a size property will be more work.
            //TODO: Add a size property
            if (Position > 1)
            {
                //Make a temp node that starts at the head. This way we don't need to actually
                //move the Head pointer. We can just use the temp node
                Node tempNode = Head;
                //Set a last node to null. It will be used for the delete
                Node previousTempNode = null;
                //Start a counter to know if we have reached the position yet or not
                int count = 0;

                //while the tempNode is not null, we can continue to walk through the
                //linked list. If it is null, then we have reached the end.
                while (tempNode != null)
                {
                    //If the count is the same as the position entered - 1, then we have found
                    //the one we would like to delete.
                    if (count == Position - 1)
                    {
                        //Set the last node's Next property to the tempNode's next property
                        //Jumping over tempNone. The previous node's next will now point
                        //to the node AFTER the tempNode
                        previousTempNode.Next = tempNode.Next;

                        if (tempNode.Next == null)
                        {
                            last = previousTempNode;
                        }
                        //Remove the next pointer of the tempNode
                        tempNode.Next = null;
                        //Return true because it was successful
                        return true;
                    }
                    //increment the counter since we are going to move forward in the list
                    count++;
                    //Set the lastNode equal to the tmpNode. Now both variables are pointing to
                    //the exact same node.
                    previousTempNode = tempNode;
                    //Now set the tempNode to tempNode's Next node, This will move tempNode
                    //one more location forward in the list
                    tempNode = tempNode.Next;
                }
            }
            //tempNode became null, so apparently we did not find it. Return False.
            return false;
        }

        public Node Retrieve(int Position)
        {
            //Set the tempNode to the head so we are at the start of the list
            Node tempNode = Head;
            //A node thst will be used to return the actual node we are looking for
            Node returnNode = null;
            //Counter to see where we are in the list
            int count = 0;

            //While our tempNode is not at the end of the list
            while (tempNode != null)
            {
                //If the count matches the position that we are looking for, we have found it
                if (count == Position - 1)
                {
                    //Set the returnNode var to the tempNode, which is the one we are looking for
                    returnNode = tempNode;
                    //Break out of the loop. No need to keep looking
                    break;
                }
                //Increase our counter since we haven't found it yet
                count++;
                //Set the tempNode we are using for walking to the next node in the list
                tempNode = tempNode.Next;
            }
            return returnNode;

        }
    }
}
