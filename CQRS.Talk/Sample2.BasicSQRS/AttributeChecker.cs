using System;

namespace CQRS.Talk.Sample2.BasicSQRS
{
    public class CheckAttributeQuery
    {
        public CheckAttributeQuery(/*requests dependencies needed to read data */)
        {
        }

        public bool AttributeExists(String attributeName)
        {
            // reach into storage and check
            return true;
        }
    }


    public class SetAttributeCommand
    {
        public SetAttributeCommand(/*requests dependecies needed to write to storage*/)
        {
        }

        public void SetAttribute(String attributeName, String value)
        {
            // reach into storage and update the attribute
        }
    }


    public class Consumer
    {
        private readonly CheckAttributeQuery query;
        private readonly SetAttributeCommand command;

        // injecting command and query dependencies
        public Consumer(CheckAttributeQuery query, SetAttributeCommand command)
        {
            this.query = query;
            this.command = command;
        }


        public void SomeOperation()
        {
            if (query.AttributeExists("DeviceName"))
            {
                command.SetAttribute("DeviceName", "Rover, Curiousity");
            }
        }
    }

/*
Note that Query and Command can take different dependencies
*/
}