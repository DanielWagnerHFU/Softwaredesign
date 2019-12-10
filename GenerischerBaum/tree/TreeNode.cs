using System;
using System.Collections.Generic;

namespace GenerischerBaum
{
    class TreeNode<T>
    {
        /*____DELEGATES____*/

        public delegate void ModifyContent(TreeNode<T> treeNode);
        public delegate void EventMethod();

        /*____ATTRIBUTES____*/

        private class EventListenerTouple{
            public List<EventMethod> methodsToCall;
            public string eventMethod;
            public EventListenerTouple(string eventMethod)
            {
                this.methodsToCall = new List<EventMethod>();
                this.eventMethod = eventMethod;
            }
            public void AddMethodToCall(EventMethod methodToCall){
                methodsToCall.Add(methodToCall);
            }
            /*returns the combined methods for an event*/
            public EventMethod ReturnCombinedMethods(){
                EventMethod combinedMethods = this.methodsToCall[0];
                for(int i = 1; i < this.methodsToCall.Count; i++){
                    combinedMethods += this.methodsToCall[i];
                }
                return combinedMethods;
            }
        }
        private List<EventListenerTouple> eventListenerTable;
        private TreeNode<T> parentNode;
        private List<TreeNode<T>> childNodes;
        private T content;

        /*____METHODS____*/
        public TreeNode(TreeNode<T> parentNode, T content)
        {
            this.parentNode = parentNode;
            this.childNodes = new List<TreeNode<T>>();
            this.content = content;
            initializeEventListenerTable();
        }
        private void initializeEventListenerTable(){
            this.eventListenerTable = new List<EventListenerTouple>();
        }
        /*The method CreateNode returns a new treenode 
        containing the given content*/
        public TreeNode<T> CreateNode(T content)
        {
            return new TreeNode<T>(null, content);
        }
        /*The method IsNodeInBranch searches for a treenode in 
        and under the treenode which executes the method(it does
        matter which node executes the method)*/
        public bool IsNodeInBranch(TreeNode<T> searchNode)
        {
            bool isBelow = false;
            if (this == searchNode)
            {
                isBelow = true;
            }
            int index = 0;
            while ((isBelow == false) && (index < this.childNodes.Count))
            {
                isBelow = childNodes[index].IsNodeInBranch(searchNode);
                index++;
            }
            return isBelow;
        }
        /*The method IsNodeInTree searches for a treenode in 
        and under the complete tree (it does not matter which node 
        of the tree executes the method)*/
        public bool IsNodeInTree(TreeNode<T> searchNode)
        {
            TreeNode<T> root = GetTreeRoot();
            return root.IsNodeInBranch(searchNode); ;
        }
        /*The method GetChildNodes returns the childnodes list*/
        public List<TreeNode<T>> GetChildNodes(){
            return this.childNodes;
        }
        /*The method GetTreeRoot returns the rootnode of the tree*/
        public TreeNode<T> GetTreeRoot()
        {
            return (this.parentNode != null) ? this.parentNode.GetTreeRoot() : this;
        }
        /*The method SetParent sets the parentNode to the given parent*/
        public void SetParent(TreeNode<T> parentNode)
        {
            this.parentNode = parentNode;
        }
        /*The method GetContent returns the content of the Node*/
        public T GetContent()
        {
            return this.content;
        }
        /*The method SetContent sets the content of the Node*/
        public void SetContent(T content)
        {
            this.content = content;
        }
        /*The method AppandChild adds a childnode to the node*/
        public void AppendChild(TreeNode<T> childNode)
        {
                EventListenerTouple methods= eventListenerTable.Find((EventListenerTouple touple) => touple.eventMethod.Equals("AppendChild"));
                if (methods != null){
                    EventMethod thisMethod = methods.ReturnCombinedMethods();
                    thisMethod();
                }

            if (IsNodeInTree(childNode))
            {
                throw new System.ArgumentException("The childnode is already in the tree");
            }
            else
            {
                childNode.SetParent(this); //secures that the parent is correctly set
                this.childNodes.Add(childNode);
            }
        }
        /*The method RemoveChild removes a given childNode from the childNodes List*/
        public void RemoveChild(TreeNode<T> childNode)
        {
            if (childNodes.Contains(childNode))
            {
                childNodes.Remove(childNode);
            }
            else
            {
                throw new System.ArgumentException("The given childnode doesnt Exist in the chilnodes list");
            }
        }
        /*The method ToString returns a string 
        containing the info of the content*/
        public override string ToString()
        {
            return content.ToString();
        }
        /*The method PrintTree prints the complete tree to the Console*/
        public void PrintTree()
        {
            Console.WriteLine(GetTreeRoot().GetBranchInformation(""));
        }
        /*The method GetBranchInformation returns 
        the content and the structure of the branch*/
        private string GetBranchInformation(string hierarchicalDepth)
        {
            string information = hierarchicalDepth + content.ToString();
            foreach (TreeNode<T> childNode in childNodes)
            {
                information += "\n" + childNode.GetBranchInformation(hierarchicalDepth + "*"); //recursive method call
            }
            return information;
        }
        /*The method ForEach executed the given delegate method for each node in the branch*/
        public void ForEach(ModifyContent method)
        {
            method(this);
            foreach (TreeNode<T> childNode in childNodes)
            {
                childNode.ForEach(method);
            }
        }
        /*The method AddEventListener adds a method to a event of this class*/
        public void AddEventListener(string eventMethod, EventMethod methodToCall){
            int index = eventListenerTable.FindIndex((EventListenerTouple touple) => touple.eventMethod.Equals(eventMethod));
            if(index != -1){
                eventListenerTable[index].AddMethodToCall(methodToCall);
            } else {
                EventListenerTouple newListener = new EventListenerTouple(eventMethod);
                newListener.AddMethodToCall(methodToCall);
                eventListenerTable.Add(newListener);
            }
        }
    }
}