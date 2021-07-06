using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmallBasket
{
    class LowLevelSample
    {
        public static async Task ExecuteAsync()
        {
            try
            {
                using (IAmazonDynamoDB ddbClient = new AmazonDynamoDBClient())
                {
                    await ddbClient.PutItemAsync(new PutItemRequest
                    {
                        TableName = "Table",
                        Item = new Dictionary<string, AttributeValue>
                    {
                        {"id",new AttributeValue{S="pranavlodh@gmail.com"} },
                        {"Name",new AttributeValue{S="{Pranav Lodh"} },
                        {"Interests",new AttributeValue
                        {
                            L=new List<AttributeValue>
                            {
                                new AttributeValue{S="Hiking"},
                                new AttributeValue{S="Boating"},
                                new AttributeValue{S="Trekking"}
                            }
                        }
                        }
                    }
                    });
                    Console.WriteLine("Data Saved");


                    Dictionary<string, AttributeValue> item = (await ddbClient.GetItemAsync(new GetItemRequest
                    {
                        TableName = "Users",
                        ConsistentRead = true,
                        Key = new Dictionary<string, AttributeValue>
                    {
                        { "id",new AttributeValue{S="pranavlodh@gmail.com"} }
                    }
                    })).Item;
                    AttributeValue value = null;
                    //item.TryGetValue("id",out value);
                    Console.WriteLine(item.TryGetValue("id", out value).ToString());
                    Console.WriteLine(value.S);


                    await ddbClient.DeleteItemAsync(new DeleteItemRequest
                    {
                        TableName = "Users",
                        Key = new Dictionary<string, AttributeValue>
                    {
                        { "id",new AttributeValue{S="pranavlodh@gmail.com"} },
                        { "Name",new AttributeValue{S="Pranav"} }
                    }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured" + Convert.ToString(ex));
            }
        }

        public static async Task InsertDataInto(string TableName, string[] columns)
        {
            using (IAmazonDynamoDB ddbClient = new AmazonDynamoDBClient())
            {
                await ddbClient.PutItemAsync(new PutItemRequest
                {
                    TableName = TableName,
                    Item = new Dictionary<string, AttributeValue>
                    {
                        {"id",new AttributeValue{S="pranavlodh@gmail.com"} },
                        {"Name",new AttributeValue{S="{Pranav Lodh"} },
                        {"Interests",new AttributeValue
                        {
                            L=new List<AttributeValue>
                            {
                                new AttributeValue{S="Hiking"},
                                new AttributeValue{S="Boating"},
                                new AttributeValue{S="Trekking"}
                            }
                        }
                        }
                    }
                });
                Console.WriteLine("Data Saved");
            }
        }

        public static async Task<string> GetOutputFromTable(string TableName, string[] columns, string[] values)
        {
            if (columns.Length == values.Length)
            {
                using (IAmazonDynamoDB ddbClient = new AmazonDynamoDBClient())
                {
                    Dictionary<string, AttributeValue> item = (await ddbClient.GetItemAsync(new GetItemRequest
                    {
                        TableName = TableName,
                        ConsistentRead = true,
                        Key = new Dictionary<string, AttributeValue>
                    {
                        { columns[0],new AttributeValue{S=values[0]} }
                    }
                    })).Item;
                    AttributeValue value = null;
                    //item.TryGetValue("id",out value);
                    Console.WriteLine(item.TryGetValue("id", out value).ToString());
                    Console.WriteLine(value.S);
                    return value.S;
                }
            }
            else
            {
                return "Failed";
            }
        }

        public static async Task DeleteOutputFromTable(string TableName)
        {
            using (IAmazonDynamoDB ddbClient = new AmazonDynamoDBClient())
            {
                await ddbClient.DeleteItemAsync(new DeleteItemRequest
                {
                    TableName = TableName,
                    Key = new Dictionary<string, AttributeValue>
                    {
                        { "id",new AttributeValue{S="pranavlodh@gmail.com"} },
                        { "Name",new AttributeValue{S="Pranav"} }
                    }
                });
            }
        }

        //Defined FOr SOLID Property-SIngle Function Method-Start
        private static string PrintResults(Dictionary<string, AttributeValue> item)
        {
            AttributeValue value = null;
            item.TryGetValue("id", out value).ToString();
            return value.S;
        }
        //Defined FOr SOLID Property-SIngle Function Method-End
    }
}
