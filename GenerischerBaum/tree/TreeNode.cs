using System;
using System.Collections.Generic;

namespace GenerischerBaum
{
    public class TreeNode<T>
    {
        public delegate void ModifyContent(TreeNode<T> treeNode);
        private TreeNode<T> parentNode;
        private List<TreeNode<T>> childNodes;
        private T content;
        public TreeNode(TreeNode<T> parentNode, T content)
        {
            this.parentNode = parentNode;
            this.childNodes = new List<TreeNode<T>>();
            this.content = content;
        }
        /*The method CreateNode returns a new treenode 
        containing the given content*/
        public TreeNode<T> CreateNode(T content){
            return new TreeNode<T>(null, content);
        }
        /*The method CreateChildNode creates a childnode with content*/
        public void CreateChildNode(T content){
            childNodes.Add(new TreeNode<T>(this, content));
        }
        /*The method IsNodeInBranch searches for a treenode in 
        and under the treenode which executes the method(it does
        matter which node executes the method)*/
        public bool IsNodeInBranch(TreeNode<T> searchNode){
            bool isBelow = false;
            if(this == searchNode){
                isBelow = true;
            }
            int index = 0;
            while((isBelow == false) && (index < this.childNodes.Count)){
                isBelow = childNodes[index].IsNodeInBranch(searchNode);
                index++;
            }
            return isBelow;
        }
        /*The method IsNodeInTree searches for a treenode in 
        and under the complete tree (it does not matter which node 
        of the tree executes the method)*/
        public bool IsNodeInTree(TreeNode<T> searchNode){
            TreeNode<T> root = GetTreeRoot();
            return root.IsNodeInBranch(searchNode);;
        }
        /*The method GetTreeRoot returns the rootnode of the tree*/
        public TreeNode<T> GetTreeRoot(){
            return (this.parentNode != null)?  this.parentNode.GetTreeRoot() : this;
        }
        /*The method SetParent sets the parentNode to the given parent*/
        public void SetParent(TreeNode<T> parentNode){
            this.parentNode = parentNode;
        }
        /*The method AppandChild adds a childnode to the node*/
        public void AppendChild(TreeNode<T> childNode){
            if(IsNodeInTree(childNode)){
                throw new System.ArgumentException("the childnode is already in the tree");
            } else {
                childNode.SetParent(this); //secures that the parent is correctly set
                this.childNodes.Add(childNode);
            }
        }
        /*The method RemoveChild removes a given childNode from the childNodes List*/
        public void RemoveChild(TreeNode<T> childNode){
            if(childNodes.Contains(childNode)){
                childNodes.Remove(childNode);
            } else {
                throw new System.ArgumentException("The given childNode doesnt Exist in the chilNodes");
            }
        }
        /*The method ToString returns a string 
        containing the info of the content*/
        public override string ToString(){
            return content.ToString();
        }
        /*The method PrintTree prints the complete tree to the Console*/
        public void PrintTree(){
            Console.WriteLine(GetTreeRoot().GetBranchInformation(0));
        }
        /*The method GetBranchInformation returns 
        the content and the structure of the branch*/
        private string GetBranchInformation(int layer){
            string information = "";
            for(int i = 0; i < layer; i++){
                information += "*"; //shows the depthlayer of the tree
            }
            information += content.ToString();
            foreach(TreeNode<T> childNode in childNodes){
                information += "\n" + childNode.GetBranchInformation(layer + 1); //recursive method call
            }
            return information;
        }
        public void ForEach(ModifyContent method){
            method(this);
            foreach(TreeNode<T> childNode in childNodes){
                childNode.ForEach(method);
            }
        }
    }
}