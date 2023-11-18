﻿using System;
using System.Collections;


namespace Mediator.Examples
{
    // "Mediator"
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    // "ConcreteMediator"
    class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;
        private ConcreteColleague3 colleague3;

        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }
        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }
        public ConcreteColleague3 Colleague3
        {
            set { colleague3 = value; }
        }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague3)
            {
                colleague1.Notify(message);
                colleague2.Notify(message);
            }
            else if (colleague == colleague1)
            {
                colleague3.Notify(message);
            }
            else if (colleague == colleague2)
            {
                colleague3.Notify(message);
            }
        }
    }

    // "Colleague"
    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    // "ConcreteColleague1"
    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: " + message);
        }
    }

    // "ConcreteColleague2"
    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: " + message);
        }
    }

    // "ConcreteColleague3"
    class ConcreteColleague3 : Colleague
    {
        public ConcreteColleague3(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague3 gets message: " + message);
        }
    }

    // Mainapp test application
    class MainApp
    {
        static void Main()
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            ConcreteColleague3 c3 = new ConcreteColleague3(m);
            m.Colleague1 = c1;
            m.Colleague2 = c2;
            m.Colleague3 = c3;

            c3.Send("How are you, what's up bro?");
            c1.Send("Alrite, thanks!");
            c2.Send("Fine, thanks!");

            // Wait for user
            Console.Read();
        }
    }
}
