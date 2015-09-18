#pragma warning disable RECS0004 // An empty public constructor without paramaters is redundant.
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
        private readonly CheckAttributeQuery attributeQuery;
        private readonly SetAttributeCommand setAttributeCommand;

        // injecting command and query dependencies
        public Consumer(CheckAttributeQuery attributeQuery, SetAttributeCommand setAttributeCommand)
        {
            this.attributeQuery = attributeQuery;
            this.setAttributeCommand = setAttributeCommand;
        }


        public void SomeOperation()
        {
            if (attributeQuery.AttributeExists("PersonName"))
            {
                setAttributeCommand.SetAttribute("PersonName", "Rover, Curiousity");
            }
        }
    }

    /*
    Note that Query and Command can take different dependencies
    */
}
