using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs
{
    public partial class Lab3_tree : Form
    {
        FamilyTree familyTree = new FamilyTree();
        private Form1 home;
        Font drawFont = new Font("Arial", 10);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        SolidBrush nodeBrush = new SolidBrush(Color.Brown);
        Pen childPen = new Pen(Color.Green);
        Pen spousePen = new Pen(Color.Black);
        Pen parentPen = new Pen(Color.Red);
        public Lab3_tree(Form1 home)
        {
            this.home = home;
            InitializeComponent();
        }

        public class Node
        {
            private int nodeId;

            
            private int id;

            
            private List<Int32> childs;

            
            private int parent1;

           
            private int parent2;

           
            private int age;

      
            public volatile int curX;
         
            public volatile int curY;

            private int treeId;

       
            public bool passed = false;

           
            private List<Node> nodes;

            public Node()
            {
                nodes = new List<Node>();
                childs = new List<Int32>();
            }

            public Node(Person person)
            {
                childs = new List<Int32>();
                nodes = new List<Node>();
                childs.Add(person.getId());
                this.parent1 = person.getParent1();
                this.parent2 = person.getParent2();
            }

            public int getParent1()
            {
                return parent1;
            }

            public void setParent1(int parent1)
            {
                this.parent1 = parent1;
            }

            public int getParent2()
            {
                return parent2;
            }

            public void setParent2(int parent2)
            {
                this.parent2 = parent2;
            }

            public int getId()
            {
                return id;
            }

            public void setId(int id)
            {
                this.id = id;
            }

            public int getAge()
            {
                return age;
            }

            public void setAge(int age)
            {
                this.age = age;
            }

            public void add(Person person)
            {
                childs.Add(person.getId());
            }

            public void add(Node node)
            {
                nodes.Add(node);
            }

            public List<Int32> getChilds()
            {
                return childs;
            }

            public void setChilds(String c) 
            {
                String [] childs = c.Split(';');
                for (int i = 0; i<childs.Length; i++) {
                    this.childs.Add(Int32.Parse(childs[i]));
                }
            }

            public void setChilds(List<Int32> childs)
            {
                this.childs = childs;
            }

            public bool isSameParents(Person person)
            {
                if (parent1 == Constants.EMPTY && parent2 == Constants.EMPTY)
                {
                    return false;
                }
                else
                {
                    return parent1 == person.getParent1() && parent2 == person.getParent2() || parent1 == person.getParent2() && parent2 == person.getParent1();
                }
            }

            public bool childIsParent(Node node)
            {
                foreach (Int32 integer in childs)
                {
                    if (node.parent1 == integer || node.parent2 == integer)
                    {
                        return true;
                    }
                }


                return false;
            }

            public void removeChild(int person)
            {
                Int32 id = -1;
                foreach (Int32 child in childs)
                {
                    if (child == person)
                    {
                        id = child;
                        break;
                    }
                }

                childs.Remove(id);
            }

            public bool isParent(int id)
            {
                return id == parent1 || id == parent2;
            }

            public void removeParent(Person person)
            {
                if (person.getId() == parent1)
                {
                    parent1 = Constants.EMPTY;
                }
                else if (person.getId() == parent2)
                {
                    parent2 = Constants.EMPTY;
                }
            }

            public void setCoordinates(int x, int y)
            {
                passed = true;
                curX = x;
                curY = y;
                int temp = 0;
                foreach (Node node in nodes)
                {
                    if (node.passed == false)
                    {
                        node.curX = curX + temp;
                        node.curY = curY + Constants.Y_STEP;
                        temp += Constants.X_STEP;
                        setCoordinates(node);
                    }
                }
            }
            private void setCoordinates(Node n)
            {
                int temp = 0;
                n.passed = true;
                foreach (Node node in n.nodes)
                {
                    if (node.passed == false)
                    {
                        node.curX = n.curX + temp;
                        node.curY = n.curY + Constants.Y_STEP;
                        temp += Constants.X_STEP;
                        setCoordinates(node);
                    }
                }
            }

            public String getCSV()
            {
                StringBuilder result = new StringBuilder();

                foreach (Int32 child in childs)
                {
                    result.Append(child + ";");
                }

                return id + "," + age + "," + curX + "," + curY + "," +
                            parent1 + "," + parent2 + "," + result;
            }
  
            public int compareTo(Node o)
            {
                return age - o.age;
            }

            public String toString()
            {
                        StringBuilder result = new StringBuilder();

                        foreach (Int32 child in childs)
                        {
                            result.Append(child + " - ");
                }

                return "p1: " + parent1 + " p2: " + parent2 + " c: " + result.ToString();
            }

            public int getCurX()
            {
                return curX;
            }

            public void setCurX(int curX)
            {
                this.curX = curX;
            }

            public int getCurY()
            {
                return curY;
            }

            public void setCurY(int curY)
            {
                this.curY = curY;
            }

            public int getTreeId()
            {
                return treeId;
            }

            public void setTreeId(int treeId)
            {
                this.treeId = treeId;
            }

            public int getNodeId()
            {
                return nodeId;
            }

            public void setNodeId(int nodeId)
            {
                this.nodeId = nodeId;
            }
        }

        public class Person
        {

            private int personId;
            
            private Int32 id;
          
            private String firstName;

            private String lastName;
           
            private int day;
         
            private int month;
         
            private int year;

            private int parent1;

            private int parent2;

            private int spouse;

            public int curX = 0;

            public int curY = 0;

            private int treeId;

            public Person(Person person)
            {
                this.id = person.id;
                this.firstName = person.firstName;
                this.lastName = person.lastName;
                this.day = person.day;
                this.month = person.month;
                this.year = person.year;
                this.parent1 = person.parent1;
                this.parent2 = person.parent2;
                this.spouse = person.spouse;
                this.curX = person.curX;
                this.curY = person.curY;
                this.treeId = person.treeId;
            }

            public Person(String firstName, String lastName, String middleName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.parent1 = Constants.EMPTY;
                this.parent2 = Constants.EMPTY;
                this.spouse = Constants.EMPTY;
                this.day = Constants.EMPTY;
                this.year = Constants.EMPTY;
                this.month = Constants.EMPTY;
                this.treeId = Constants.EMPTY;
            }

            public Person()
            {
                this.firstName = "";
                this.lastName = "";
                this.parent1 = Constants.EMPTY;
                this.parent2 = Constants.EMPTY;
                this.spouse = Constants.EMPTY;
                this.day = Constants.EMPTY;
                this.year = Constants.EMPTY;
                this.month = Constants.EMPTY;
                this.treeId = Constants.EMPTY;
            }

            public void setPerson(Person person)
            {
                this.id = person.id;
                this.firstName = person.firstName;
                this.lastName = person.lastName;
                this.day = person.day;
                this.month = person.month;
                this.year = person.year;
                this.parent1 = person.parent1;
                this.parent2 = person.parent2;
                this.spouse = person.spouse;
                this.treeId = person.treeId;
            }

            public String getFullName()
            {
                return lastName + " " + firstName;
            }

            public String getFirstName()
            {
                return firstName;
            }

            public void setFirstName(String firstName)
            {
                this.firstName = firstName;
            }

            public String getLastName()
            {
                return lastName;
            }

            public void setLastName(String lastName)
            {
                this.lastName = lastName;
            }

            public void setBirthDay(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public void setBirthDay(String date) 
            {
                String [] dateParts = date.Split('.');
                if (dateParts.Length != 3) {
                    dateParts = date.Split('/');
                }

                this.year = Int32.Parse(dateParts[2]);
                this.month = Int32.Parse(dateParts[1]);
                this.day = Int32.Parse(dateParts[0]);
            }

            public String getBirthDay()
            {
                return day + "." + month + "." + year;
            }

            public bool hasBirthDay()
            {
                if (day == Constants.EMPTY || month == Constants.EMPTY ||
                        year == Constants.EMPTY)
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }

            public int getId()
            {
                return id;
            }

            public void setId(int id)
            {
                this.id = id;
            }

            public int getParent1()
            {
                return parent1;
            }

            public void setParent1(int parent1)
            {
                this.parent1 = parent1;
            }

            public int getParent2()
            {
                return parent2;
            }

            public void setParent2(int parent2)
            {
                this.parent2 = parent2;
            }

            public int getSpouse()
            {
                return spouse;
            }

            public void setSpouse(int spouse)
            {
                this.spouse = spouse;
            }

            public String getBirthInfo()
            {
                if (day == Constants.EMPTY || month == Constants.EMPTY || year == Constants.EMPTY)
                {
                    return "";
                }
                else
                {
                    return day + "." + month + "." + year;
                }
            }

            public String getShortName()
            {
                StringBuilder result = new StringBuilder();
                if (firstName.Length >= 1)
                {
                    result.Append(firstName[0] + ". ");
                }
                return lastName + " " + result;
            }

            public String getCSV()
            {
                return id + "," + firstName + "," + lastName + "," + parent1 + "," + parent2 + "," + spouse + "," + curX + "," + curY;
            }

            public int getYear()
            {
                return year;
            }

            public bool hasParent()
            {
                return parent1 != Constants.EMPTY || parent2 != Constants.EMPTY;
            }

            public bool isSameParent(Person person)
            {
                return parent1 != Constants.EMPTY && parent2 != Constants.EMPTY &&
                            (parent1 == person.getParent1() && parent2 == person.getParent2() ||
                            parent1 == person.getParent2() && parent2 == person.getParent1());
            }
            public int hashCode()
            {
                return id;
            }

  
            public bool equals(Object obj)
            {

                if (obj is Person) {

                    Person person = (Person)obj;

                    return person.id == this.id && person.treeId == this.treeId;
                } else
                {
                    return false;
                }
            }


            public String toString()
            {

                return id + ": " + firstName + " " + lastName;
            }


            public int getDay()
            {
                return day;
            }

            public void setDay(int day)
            {
                this.day = day;
            }

            public int getMonth()
            {
                return month;
            }

            public void setMonth(int month)
            {
                this.month = month;
            }

            public void setYear(int year)
            {
                this.year = year;
            }
            public int getCurX()
            {
                return curX;
            }

            public void setCurX(int curX)
            {
                this.curX = curX;
            }

            public int getCurY()
            {
                return curY;
            }

            public void setCurY(int curY)
            {
                this.curY = curY;
            }

            public int getTreeId()
            {
                return treeId;
            }

            public void setTreeId(int treeId)
            {
                this.treeId = treeId;
            }

            public int getPersonId()
            {
                return personId;
            }

            public void setPersonId(int personId)
            {
                this.personId = personId;
            }
        }

        public class Constants
        {
            public static readonly int ICON_WIDTH = 100;
            public static readonly int ICON_HEIGHT = 30;
            public static readonly int NODE_WIDTH = 10;
            public static readonly int NODE_HEIGHT = 10;
            public static readonly int EMPTY = 0;
            public static readonly int X_STEP = 300;
            public static readonly int Y_STEP = 100;
            public static readonly int BRANCH_WIDTH = 20;
            public static readonly int LINE_WIDTH = 5;
        }

        public class FamilyTree
        {            
            private Int32 id;
            
            private volatile List<Person> persons;

            private volatile List<Node> nodes;

            private int lastID;

            public FamilyTree()
            {

                persons = new List<Person>();
                nodes = new List<Node>();

                lastID = 0;
            }

            public int addNew(Person person)
            {

                lastID++;
                person.setId(lastID);

                persons.Add(person);
                bool inNode = false;

                foreach (Node item in nodes)
                {
                    if (item.isSameParents(person))
                    {
                        item.add(person);
                        inNode = true;
                        int age = item.getAge() > person.getYear() ? item.getAge() : person.getYear();

                        item.setAge(age);

                        break;
                    }
                }

                if (inNode == false)
                {
                    Node node = new Node(person);
                    node.setId(nodes.Count);
                    node.setAge(person.getYear());

                    nodes.Add(node);
                }

                return persons.Count;
            }

            private void setNodes()
            {
                foreach (Person person in persons)
                {

                    person.curX = Constants.EMPTY;
                    person.curY = Constants.EMPTY;

                    bool inNode = false;

                    foreach (Node item in nodes)
                    {
                        if (item.isSameParents(person))
                        {
                            item.add(person);
                            inNode = true;
                            int age = item.getAge() > person.getYear() ? item.getAge() : person.getYear();
                            item.setAge(age);
                            break;
                        }
                    }

                    if (inNode == false)
                    {
                        Node node = new Node(person);
                        node.setId(nodes.Count);
                        node.setAge(person.getYear());
                        nodes.Add(node);
                    }
                }
            }

            private void setGraph()
            {
                foreach (Node node in nodes)
                {
                    node.passed = false;
                    foreach (Node subNode in nodes)
                    {
                        if (subNode.Equals(node) == false)
                        {
                            if (node.childIsParent(subNode))
                            {
                                node.add(subNode);
                            }
                        }
                    }
                }
            }

            private void setNodesCoordinates()
            {
                nodes.Sort((x, y) => x.getAge().CompareTo(y.getAge()));
                int step = 200;
                foreach (Node item in nodes)
                {
                    if (item.getParent1() == Constants.EMPTY &&
                            item.getParent2() == Constants.EMPTY && item.passed == false)
                    {

                        item.setCoordinates(step, 0);
                        step += Constants.X_STEP;
                    }
                }
            }

            private void setPersonsCoordinates()
            {
                foreach (Node node in nodes)
                {
                    if (node.getParent1() != Constants.EMPTY)
                    {
                        Person parent = findById(node.getParent1());

                        parent.curX = node.curX - Constants.ICON_WIDTH;
                        parent.curY = node.curY - Constants.ICON_HEIGHT;

                    }
                    if (node.getParent2() != Constants.EMPTY)
                    {
                        Person parent = findById(node.getParent2());

                        parent.curX = node.curX + Constants.NODE_WIDTH;
                        parent.curY = node.curY - Constants.ICON_HEIGHT;
                    }

                    Person tempPerson;
                    int t = (node.getChilds().Count * Constants.ICON_WIDTH) / 2;
                    foreach (Int32 id in node.getChilds())
                    {
                        tempPerson = findById(id);
                        if (tempPerson.curX == Constants.EMPTY && tempPerson.curY == Constants.EMPTY)
                        {
                            tempPerson.curX = node.curX - t + Constants.NODE_WIDTH / 2;
                            tempPerson.curY = node.curY + Constants.ICON_HEIGHT;
                        }
                        t -= Constants.ICON_WIDTH;
                    }
                }
            }

            public void fixNodes()
            {

                nodes.Clear();

                setNodes();
                setGraph();

                setNodesCoordinates();
                setPersonsCoordinates();
            }

            public bool fixFamilyLinks(Person curPerson, Person changedPerson)
            {
                bool inNodes = false;
                foreach (Node node in nodes)
                {
                    if (node.isSameParents(curPerson))
                    {
                        node.removeChild(curPerson.getId());
                    }
                    else if (node.isSameParents(changedPerson))
                    {
                        node.add(changedPerson);
                        inNodes = true;
                    }
                }

                if (inNodes == false)
                {
                    Node node = new Node(changedPerson);
                    nodes.Add(node);
                }

                return inNodes;
            }

            public void remove(Person person)
            {
                persons.Remove(person);

                foreach (Node item in nodes)
                {
                    if (item.isSameParents(person))
                    {
                        item.removeChild(person.getId());
                    }
                    if (item.isParent(person.getId()))
                    {
                        item.removeParent(person);
                        Person child;
                        foreach (Int32 id in item.getChilds())
                        {
                            child = findById(id);
                            if (child.getParent1() == person.getId())
                            {
                                child.setParent1(Constants.EMPTY);
                            }
                            else
                            {
                                child.setParent2(Constants.EMPTY);
                            }
                        }
                    }
                }

                foreach (Person human in persons)
                {
                    if (human.getSpouse() == person.getId())
                    {
                        human.setSpouse(Constants.EMPTY);
                        break;
                    }
                }
            }

            public List<Node> getNodes()
            {
                return nodes;
            }

            public void setNodes(List<Node> nodes)
            {
                this.nodes = nodes;
            }

            public List<Person> getPersons()
            {
                return persons;
            }

            public Person findById(int id) 
            {
                foreach (Person item in persons) {
                    if (item.getId() == id) {
                        return item;
                    }
                }

                return null;
            }

            public int[] getFurtherPoint()
            {
                int[] point = { 0, 0 };
                foreach (Person person in persons) {
                    point[0] = point[0] >= person.curX ? point[0] : person.curX;
                    point[1] = point[1] >= person.curY ? point[1] : person.curY;
                }

                return point;
            }

            public Person[] getPersonsArray()
            {
                Person[] list = new Person[persons.Count + 1];
                int i = 0;
                list[i++] = new Person("Нет", "", "");
                list[0].setId(Constants.EMPTY);
                foreach (Person person in persons) {
                    list[i++] = person;
                }
                return list;
            }

            public void clear()
            {
                persons.Clear();
                nodes.Clear();
            }

            public void setNewId(int id)
            {
                this.id = id;
                foreach (Person person in persons) {
                    person.setTreeId(id);
                }
                foreach (Node node in nodes)
                {
                    node.setTreeId(id);
                }
            }

            public Int32 getId()
            {
                return id;
            }

            public void setId(Int32 id)
            {
                this.id = id;
            }

            public int getLastID()
            {
                return lastID;
            }

            public void setLastID(int lastID)
            {
                this.lastID = lastID;
            }

            public void setPersons(List<Person> persons)
            {
                this.persons = persons;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String[] birthDate = textBox3.Text.Split('.');
                if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
                    throw new Exception("Неверные данные");
                if (birthDate.Length != 3) 
                    throw new Exception("Неправильная дата рождения");
                int day = Int32.Parse(birthDate[0]);
                
                int month = Int32.Parse(birthDate[1]);
                int year = Int32.Parse(birthDate[2]);
                if (day < 0 || day > 31) throw new Exception("Неправильная дата рождения");
                if (month < 0 || month > 12) throw new Exception("Неправильная дата рождения");
                Person person = new Person();
                person.setFirstName(textBox1.Text);
                person.setLastName(textBox2.Text);
                person.setBirthDay(day, month, year);
                String[] comboBox = comboBox1.Text.Split(')');
                int spouseId = Int32.Parse(comboBox[0]);
                comboBox = comboBox2.Text.Split(')');
                int parent1Id = Int32.Parse(comboBox[0]);
                comboBox = comboBox3.Text.Split(')');
                int parent2Id = Int32.Parse(comboBox[0]);
                 if ((parent1Id == parent2Id && parent1Id != 0 || parent1Id == spouseId && parent1Id != 0 || parent2Id == spouseId && parent2Id != 0))
                {
                    throw new Exception("Неверные данные");
                }
                Person spouse = familyTree.findById(spouseId);
                if (spouse == null)
                {
                    person.setSpouse(spouseId);
                } else if (spouse.getSpouse() == 0) 
                {
                    person.setSpouse(spouseId);
                    spouse.setSpouse(familyTree.getLastID() + 1);
                } else
                {
                    Person spouseOfSpouse = familyTree.findById(spouse.getSpouse());
                    var confirmResult = MessageBox.Show("Ты хочешь увести супруг(а/у) у " + spouseOfSpouse.getShortName() + "???",
                                     "Жду ответа...",
                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        person.setSpouse(spouseId);
                        spouse.setSpouse(familyTree.getLastID() + 1);
                        spouseOfSpouse.setSpouse(0);
                    }
                }
               
                
                person.setParent1(parent1Id);
                person.setParent2(parent2Id);

                int personId = this.familyTree.addNew(person);
                comboBox1.Items.Add(personId + ") " + person.getFullName());
                comboBox2.Items.Add(personId + ") " + person.getFullName());
                comboBox3.Items.Add(personId + ") " + person.getFullName());
                comboBox4.Items.Add(personId + ") " + person.getFullName());
                comboBox5.Items.Add(personId + ") " + person.getFullName());
                comboBox6.Items.Add(personId + ") " + person.getFullName());
                comboBox7.Items.Add(personId + ") " + person.getFullName());

                familyTree.fixNodes();
                pictureBox1.Refresh();
                Graphics g = pictureBox1.CreateGraphics();
                
                foreach (Node node in familyTree.getNodes())
                {
                    drawchildsColors(g, node);
                    drawParentsLines(g, node);
                }

                drawSpouseLines(g);
                foreach (Person person1 in familyTree.getPersons())
                {
                    g.DrawRectangle(spousePen, new Rectangle(person1.curX, person1.curY, person1.getShortName().Length * 7, Constants.ICON_HEIGHT - 10));
                    g.DrawString(person1.getShortName(), drawFont, drawBrush, person1.curX, person1.curY);
                }
                foreach (Node node1 in familyTree.getNodes())
                {
                    if (node1.getParent1() != Constants.EMPTY && node1.getParent2() != Constants.EMPTY)
                        g.FillRectangle(nodeBrush, new Rectangle(node1.curX, node1.curY, Constants.NODE_WIDTH, Constants.NODE_HEIGHT));
                }
            } catch (Exception exc)
            {
                home.textBox1.Text += exc.Message + exc.StackTrace;
                MessageBox.Show("Вы сделали ошибку: " + exc.Message);
            }
            
        }
        private void drawchildsColors(Graphics g, Node node)
        {
            Person temp;

            if ((node.getParent1() == Constants.EMPTY &&
                    node.getParent2() == Constants.EMPTY) == false)
            {

                foreach (Int32 id in node.getChilds())
                {
                    temp = familyTree.findById(id);
                    if (temp != null) g.DrawLine(childPen, temp.curX + Constants.ICON_WIDTH / 2, temp.curY, node.curX + Constants.NODE_HEIGHT / 2, node.curY + Constants.NODE_WIDTH / 2);
                }
            }
        }
        private void drawParentsLines(Graphics g, Node node)
        {
            Person temp;

            temp = familyTree.findById(node.getParent1());
            if (temp != null) g.DrawLine(parentPen, temp.curX+Constants.ICON_WIDTH / 2, temp.curY + Constants.ICON_HEIGHT/ 2, node.curX + Constants.NODE_HEIGHT/ 2, node.curY + Constants.NODE_WIDTH/ 2);

            temp = familyTree.findById(node.getParent2());
            if (temp != null) g.DrawLine(parentPen, temp.curX + Constants.ICON_WIDTH / 2, temp.curY + Constants.ICON_HEIGHT / 2, node.curX + Constants.NODE_HEIGHT / 2, node.curY + Constants.NODE_WIDTH / 2);

        }
        private void drawSpouseLines(Graphics g)
        {
            Person spouse;
            int personOneX = 0, personOneY = 0, personTwoX = 0, personTwoY = 0;

            foreach (Person person in familyTree.getPersons())
            {
                if (person.getSpouse() != Constants.EMPTY)
                {

                    spouse = familyTree.findById(person.getSpouse());

                    personOneX = spouse.curX + Constants.ICON_WIDTH / 2;
                    personOneY = spouse.curY + Constants.ICON_HEIGHT - 10;
                    personTwoX = person.curX + Constants.ICON_WIDTH / 2;
                    personTwoY = person.curY + Constants.ICON_HEIGHT - 10;
                    g.DrawLine(spousePen, personOneX, personOneY, personTwoX, personTwoY);
                }
            }
        }
        private void Lab3_tree_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("0) -");
            comboBox2.Items.Add("0) -");
            comboBox3.Items.Add("0) -");
            comboBox4.Items.Add("0) -");
            comboBox5.Items.Add("0) -");
            comboBox6.Items.Add("0) -");
            comboBox7.Items.Add("0) -");

            comboBox1.Text = (String)comboBox1.Items[0];
            comboBox2.Text = (String)comboBox2.Items[0];
            comboBox3.Text = (String)comboBox3.Items[0];
            comboBox4.Text = (String)comboBox4.Items[0];
            comboBox5.Text = (String)comboBox5.Items[0];
            comboBox6.Text = (String)comboBox6.Items[0];
            comboBox7.Text = (String)comboBox7.Items[0];
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String[] comboBox = comboBox4.Text.Split(')');
            int personId = Int32.Parse(comboBox[0]);
            Person person = familyTree.findById(personId);
            if (person == null) return;
            textBox6.Text = person.getFirstName();
            textBox5.Text = person.getLastName();
            textBox4.Text = person.getDay() + "." + person.getMonth() + "." + person.getYear();
            Person spouse = familyTree.findById(person.getSpouse());
            Person parent1 = familyTree.findById(person.getParent1());
            Person parent2 = familyTree.findById(person.getParent2());
            if (spouse != null) comboBox7.Text = spouse.getId() + ") " + spouse.getFullName();
            else comboBox7.Text = 0 + ") -";
            if (parent1 != null) comboBox6.Text = parent1.getId() + ") " + parent1.getFullName();
            else comboBox6.Text = 0 + ") -";
            if (parent2 != null) comboBox5.Text = parent2.getId() + ") " + parent2.getFullName();
            else comboBox5.Text = 0 + ") -";
            panel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String[] birthDate = textBox4.Text.Split('.');
                if (String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox4.Text))
                    throw new Exception("Неверные данные");
                if (birthDate.Length != 3)
                    throw new Exception("Неправильная дата рождения");
                int day = Int32.Parse(birthDate[0]);
                int month = Int32.Parse(birthDate[1]);
                int year = Int32.Parse(birthDate[2]);
                if (day < 0 || day > 31) throw new Exception("Неправильная дата рождения");
                if (month < 0 || month > 12) throw new Exception("Неправильная дата рождения");
                String[] comboBox = comboBox4.Text.Split(')');
                int personId = Int32.Parse(comboBox[0]);
                Person person = familyTree.findById(personId);
                if (person == null) return;
                person.setFirstName(textBox6.Text);
                person.setLastName(textBox5.Text);
                person.setBirthDay(day, month, year);
                comboBox = comboBox7.Text.Split(')');
                int spouseId = Int32.Parse(comboBox[0]);
                comboBox = comboBox6.Text.Split(')');
                int parent1Id = Int32.Parse(comboBox[0]);
                comboBox = comboBox5.Text.Split(')');
                int parent2Id = Int32.Parse(comboBox[0]);
                if ((parent1Id == parent2Id || parent1Id == spouseId || parent2Id == spouseId) && !(parent1Id == 0 && parent2Id == 0 && spouseId == 0))
                {
                    throw new Exception("Неверные данные");
                }
                Person spouse = familyTree.findById(spouseId);
                if (spouse == null)
                {
                    person.setSpouse(spouseId);
                }
                else if (spouse.getSpouse() == 0)
                {
                    person.setSpouse(spouseId);
                    spouse.setSpouse(familyTree.getLastID() + 1);
                }
                else
                {
                    Person spouseOfSpouse = familyTree.findById(spouse.getSpouse());
                    var confirmResult = MessageBox.Show("Ты хочешь увести супруг(а/у) у " + spouseOfSpouse.getShortName() + "???",
                                     "Жду ответа...",
                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        person.setSpouse(spouseId);
                        spouse.setSpouse(familyTree.getLastID() + 1);
                        spouseOfSpouse.setSpouse(0);
                    }
                }


                person.setParent1(parent1Id);
                person.setParent2(parent2Id);
                comboBox1.Items.Remove(comboBox4.Text);
                comboBox2.Items.Remove(comboBox4.Text);
                comboBox3.Items.Remove(comboBox4.Text);
                comboBox4.Items.Remove(comboBox4.Text);
                comboBox5.Items.Remove(comboBox4.Text);
                comboBox6.Items.Remove(comboBox4.Text);
                comboBox7.Items.Remove(comboBox4.Text);
                comboBox1.Items.Add(person.getId() + ") " + person.getFullName());
                comboBox2.Items.Add(person.getId() + ") " + person.getFullName());
                comboBox3.Items.Add(person.getId() + ") " + person.getFullName());
                comboBox4.Items.Add(person.getId() + ") " + person.getFullName());
                comboBox5.Items.Add(person.getId() + ") " + person.getFullName());
                comboBox6.Items.Add(person.getId() + ") " + person.getFullName());
                comboBox7.Items.Add(person.getId() + ") " + person.getFullName());

                familyTree.fixNodes();
                pictureBox1.Refresh();
                Graphics g = pictureBox1.CreateGraphics();

                foreach (Node node in familyTree.getNodes())
                {
                    drawchildsColors(g, node);
                    drawParentsLines(g, node);
                }

                drawSpouseLines(g);
                foreach (Person person1 in familyTree.getPersons())
                {
                    g.DrawRectangle(spousePen, new Rectangle(person1.curX, person1.curY, person1.getShortName().Length * 7, Constants.ICON_HEIGHT - 10));
                    g.DrawString(person1.getShortName(), drawFont, drawBrush, person1.curX, person1.curY);
                }
                foreach (Node node1 in familyTree.getNodes())
                {
                    if (node1.getParent1() != Constants.EMPTY && node1.getParent2() != Constants.EMPTY)
                        g.FillRectangle(nodeBrush, new Rectangle(node1.curX, node1.curY, Constants.NODE_WIDTH, Constants.NODE_HEIGHT));
                }
            }
            catch (Exception exc)
            {
                home.textBox1.Text += exc.Message + exc.StackTrace;
                MessageBox.Show("Вы сделали ошибку: " + exc.Message);
            }
        }
    }
}
