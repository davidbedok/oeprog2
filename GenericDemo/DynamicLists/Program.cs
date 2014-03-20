using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicLists.entity;
using DynamicLists.generic;
using DynamicLists.demo;

namespace DynamicLists
{
    public class Program
    {

        #region Test Generic list (simple)

        public static void testWithoutInterface()
        {
            DemoArray demoArray = new DemoArray(5);
            demoArray.addItem(10, "alma");
            demoArray.addItem(20, "korte");
            demoArray.addItem(30, "szilva");
            System.Console.WriteLine(demoArray);
            demoArray.iterate();

            DemoList demoList = new DemoList();
            demoList.addItem(10, "alma");
            demoList.addItem(20, "korte");
            demoList.addItem(30, "szilva");
            System.Console.WriteLine(demoList);
            demoList.iterate();

            DemoGenericList demoGenericList = new DemoGenericList();
            demoGenericList.addItem(10, "alma");
            demoGenericList.addItem(20, "korte");
            demoGenericList.addItem(30, "szilva");
            System.Console.WriteLine(demoGenericList);
            demoGenericList.iterate();
        }

        #endregion

        #region Test Generic list with interface

        public static void addItemAndPrint(IDemoList demoList)
        {
            demoList.addItem(10, "alma");
            demoList.addItem(20, "korte");
            demoList.addItem(30, "szilva");
            System.Console.WriteLine(demoList);
            demoList.iterate();
        }

        public static void testDynamicLists()
        {
            Program.addItemAndPrint(new DemoArray(5));
            Program.addItemAndPrint(new DemoList());
            Program.addItemAndPrint(new DemoGenericList());
        }

        #endregion

        #region Test Generic methods

        public static void testGenericMethods() {
		    TestEntity[] testEntities = new TestEntity[3];
            testEntities[0] = new TestEntity(10,"alma");
            testEntities[1] = new TestEntity(20,"korte");
            testEntities[2] = new TestEntity(30,"szilva");

            DemoEntity[] demoEntities = new DemoEntity[3];
            demoEntities[0] = new DemoEntity(10.0,'a');
            demoEntities[1] = new DemoEntity(20.0,'k');
            demoEntities[2] = new DemoEntity(30.0,'s');
            
            DummyEntity[] dummyEntities = new DummyEntity[3];
            dummyEntities[0] = new DummyEntity("10","alma");
            dummyEntities[1] = new DummyEntity("20","korte");
            dummyEntities[2] = new DummyEntity("30","szilva");

            System.Console.WriteLine("# Print arrays without generic method\n");

		    System.Console.WriteLine("Array TestEntity contains:");
		    PrintArray.printArray(testEntities);
		    System.Console.WriteLine("\nArray DemoEntity contains:");
		    PrintArray.printArray(demoEntities);
		    System.Console.WriteLine("\nArray DummyEntity contains:");
		    PrintArray.printArray(dummyEntities);

            System.Console.WriteLine("\n# Print arrays with generic method");

		    System.Console.WriteLine("\nArray TestEntity contains:");
            GenericPrintArray.printArray(testEntities);
		    System.Console.WriteLine("\nArray DemoEntity contains:");
            GenericPrintArray.printArray(demoEntities);
            System.Console.WriteLine("\nArray DummyEntity contains:");
            GenericPrintArray.printArray(dummyEntities);
	    }

        #endregion

        #region Test Simple Generic class

        public static void testSimpleGenericClass()
        {
            System.Console.WriteLine("# Simple generic class");

            GenericClass<TestEntity> genericTestClass = new GenericClass<TestEntity>(new TestEntity(10,"alma"));
            System.Console.WriteLine(genericTestClass.say());

            GenericClass<DemoEntity> genericDemoClass = new GenericClass<DemoEntity>(new DemoEntity(10.0, 'a'));
            System.Console.WriteLine(genericDemoClass.say());
        }

        #endregion

        #region Test Extended Generic class

        public static void testExtendedGenericClass()
        {
            System.Console.WriteLine("\n# Extended generic class");

            GenericExtendedClass<TestA> testA = new GenericExtendedClass<TestA>(new TestA());
            testA.print();

            GenericExtendedClass<TestB> testB = new GenericExtendedClass<TestB>(new TestB());
            testB.print();
        }

        #endregion

        #region Test Create Generic class

        public static void testCreateGenericClass()
        {
            System.Console.WriteLine("\n# Create generic class");

            GenericCreateDemo<TestA> testCreateA = new GenericCreateDemo<TestA>();
            System.Console.WriteLine(testCreateA);

            GenericCreateDemo<TestB> testCreateB = new GenericCreateDemo<TestB>();
            System.Console.WriteLine(testCreateB);
        }

        #endregion

        #region Test Extended and Create Generic class

        public static void testExtendedAndCreateGenericClass()
        {
            System.Console.WriteLine("\n# Extended and Create generic class");

            GenericExtendedAndCreate<TestA> testExtCreateA = new GenericExtendedAndCreate<TestA>();
            testExtCreateA.print();

            GenericExtendedAndCreate<TestB> testExtCreateB = new GenericExtendedAndCreate<TestB>();
            // GenericExtendedAndCreate<AbstractTest> convertToAbstractTest = (GenericExtendedAndCreate<AbstractTest>)Convert.ChangeType(testExtCreateB, typeof(GenericExtendedAndCreate<AbstractTest>));
            
            testExtCreateB.print();
        }

        #endregion

        #region Test Multi generic class

        public static void testMultiGenericClass()
        {
            System.Console.WriteLine("\n# Multi generic class");
            
            GenericMultiClass<int, string> multiClass1 = new GenericMultiClass<int, string>(10, "alma");
            System.Console.WriteLine(multiClass1);
            
            GenericMultiClass<double, char> multiClass2 = new GenericMultiClass<double, char>(10.0, 'a');
            System.Console.WriteLine(multiClass2);

            Program.callGenericParamIntString(multiClass1);

            Program.callGenericParam(multiClass1);
            Program.callGenericParam(multiClass2);
        }

        #region Method with Generic class param

        public static void callGenericParamIntString(GenericMultiClass<int, string> param)
        {
            System.Console.WriteLine(param);
        }

        #endregion

        #region Generic Method with Generic class param 

        public static void callGenericParam<E, K>(GenericMultiClass<E, K> param)
        {
            System.Console.WriteLine(param);
        }

        #endregion

        #endregion

        public static void Main(string[] args)
        {
            // Program.testWithoutInterface();
            // Program.testDynamicLists();
            // Program.testGenericMethods();
            // Program.testSimpleGenericClass();
            // Program.testExtendedGenericClass();
            // Program.testCreateGenericClass();
            // Program.testExtendedAndCreateGenericClass();
            // Program.testMultiGenericClass();
        }
    }
}
