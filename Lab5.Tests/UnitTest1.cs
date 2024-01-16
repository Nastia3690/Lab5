namespace Lab5.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Notebook notebook = new Notebook();
            List<Contact> FoundRecords = new List<Contact>();
            Predicate<Contact> predicate;
            Assert.True(notebook.Add("�������", "��������", "+79219451233", "alexvas@mail.ru"));
            Assert.True(notebook.Add("���������", "��������", "+79637492654", "amuravei@mail.ru"));
            Assert.True(notebook.Add("�����", "������", "+79214425635", "artemp@yandex.ru"));
            Assert.True(notebook.Add("�����", "������", "+79377742653", "arturivanov@mail.ru"));
            Assert.True(notebook.Add("�����", "��������", "+79374766301", "borisart@mail.ru"));
            Assert.True(notebook.Add("�������", "�����", "+79619463593", "vvserov@yandex.ru"));
            Assert.True(notebook.Add("������", "�����", "+79617443583", "sergbykov@mail.ru"));
            Assert.True(notebook.Add("��������", "�����", "+79627253254", "genbukin@mail.ru"));
            Assert.True(notebook.Add("������", "�����", "+79987742600", "sdarov@yandex.ru"));
            Assert.True(notebook.Add("�������", "������", "+79607545463", "evgpashkov@mail.ru"));
            Assert.True(notebook.Add("����", "�������", "+79677222333", "isergeev@yandex.ru"));
            FoundRecords = notebook.AllRecords;
            Assert.Equal(11, FoundRecords.Count);

            predicate = contact => contact.Name.Contains("���");
            FoundRecords = notebook.Search(predicate);
            Assert.Equal(2, FoundRecords.Count);
            Assert.Equal("������", FoundRecords[0].Surname);
            Assert.Equal("������", FoundRecords[1].Surname);

            predicate = contact => contact.Surname.Contains("���");
            FoundRecords = notebook.Search(predicate);
            Assert.Equal(2, FoundRecords.Count);
            Assert.Equal("�����", FoundRecords[0].Surname);
            Assert.Equal("�������", FoundRecords[1].Surname);

            predicate = contact => contact.Name.Contains("���") || contact.Surname.Contains("���");
            FoundRecords = notebook.Search(predicate);
            Assert.Equal(3, FoundRecords.Count);
            Assert.Equal("������", FoundRecords[0].Surname);
            Assert.Equal("������", FoundRecords[1].Surname);
            Assert.Equal("��������", FoundRecords[2].Surname);

            predicate = contact => contact.Phone.Contains("77");
            FoundRecords = notebook.Search(predicate);
            Assert.Equal(3, FoundRecords.Count);
            Assert.Equal("������", FoundRecords[0].Surname);
            Assert.Equal("�����", FoundRecords[1].Surname);
            Assert.Equal("�������", FoundRecords[2].Surname);

            predicate = contact => contact.Email.Contains("yandex.ru");
            FoundRecords = notebook.Search(predicate);
            Assert.Equal(4, FoundRecords.Count);
            Assert.Equal("������", FoundRecords[0].Surname);
            Assert.Equal("�����", FoundRecords[1].Surname);
            Assert.Equal("�����", FoundRecords[2].Surname);
            Assert.Equal("�������", FoundRecords[3].Surname);

            //SAVE
            Assert.True(notebook.SaveToXML());
            Assert.True(notebook.SaveToJSON());
            Assert.True(notebook.SaveToSQLite());
            //XML
            notebook.Clear();
            Assert.Equal(0, notebook.Count());
            Assert.True(notebook.LoadFromXML());
            Assert.Equal(11, notebook.Count());
            //JSON
            notebook.Clear();
            Assert.True(notebook.LoadFromJSON());
            Assert.Equal(11, notebook.Count());
            //SQLite
            notebook.Clear();
            Assert.True(notebook.LoadFromSQLite());
            Assert.Equal(11, notebook.Count());
        }
    }
}