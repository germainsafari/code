[Serializable]
class Administrator
{
    public List<Employee> users = new List<Employee>();
 
    public void AddUser(Employee user)
    {
        users.Add(user);
    }
 
    public void DisplayUsers()
    {
        foreach (Employee user in users)
        {
            user.DisplayInfo();
        }
    }
 
    public void SerializeEmployees()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("employees.bin", FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, users);
        stream.Close();
    }
 
    public void DeserializeEmployees()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("employees.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
        users = (List<Employee>)formatter.Deserialize(stream);
        stream.Close();
    }
}
