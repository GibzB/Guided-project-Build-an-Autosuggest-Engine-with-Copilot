namespace TrieDictionaryTest;

// Test that a word is inserted in the trie
[TestMethod]
public void InsertWord()
{
    // Arrange
    Trie trie = new Trie();
    string word = "hello";

    // Act
    trie.Insert(word);

    // Assert
    Assert.IsTrue(trie.Search(word));
}

[TestMethod]
public void TestDeleteWord()
{
    // Arrange
    Trie trie = new Trie();
    string word = "test";
    trie.Insert(word);

    // Act
    trie.Delete(word);

    // Assert
    Assert.IsFalse(trie.Search(word), "Word was not deleted from the Trie");
}


using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TrieTest
{
    [TestMethod]
    public void TestWordNotInsertedTwice()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        trie.Insert(word);

        // Act
        trie.Insert(word);

        // Assert
        Assert.AreEqual(1, trie.Count(word), "Word was inserted more than once");
    }

    [TestMethod]
    public void TestDeleteWord()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        trie.Insert(word);

        // Act
        trie.Delete(word);

        // Assert
        Assert.IsFalse(trie.Search(word), "Word was not deleted from the Trie");
    }

    [TestMethod]
    public void TestNotDeleteAbsentWord()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";

        // Act
        trie.Delete(word);

        // Assert
        Assert.IsFalse(trie.Search(word), "Word was deleted but it was not in the Trie");
    }

    [TestMethod]
    public void TestDeleteWordThatIsPrefix()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        string longerWord = "testing";
        trie.Insert(word);
        trie.Insert(longerWord);

        // Act
        trie.Delete(word);

        // Assert
        Assert.IsFalse(trie.Search(word), "Word was not deleted from the Trie");
        Assert.IsTrue(trie.Search(longerWord), "Longer word that includes the deleted word as prefix was also deleted");
    }
}
// Test AutoSuggest for the prefix "cat" not present in the 
// trie containing "catastrophe", "catatonic", and "caterpillar"
[TestMethod]
public void TestAutoSuggest()
{
    // Arrange
    Trie trie = new Trie();
    trie.Insert("catastrophe");
    trie.Insert("catatonic");
    trie.Insert("caterpillar");

    // Act
    List<string> suggestions = trie.AutoSuggest("cat");

    // Assert
    Assert.AreEqual(3, suggestions.Count, "Did not return all suggestions");
    Assert.IsTrue(suggestions.Contains("catastrophe"), "Missing suggestion: catastrophe");
    Assert.IsTrue(suggestions.Contains("catatonic"), "Missing suggestion: catatonic");
    Assert.IsTrue(suggestions.Contains("caterpillar"), "Missing suggestion: caterpillar");
}

// Test GetSpellingSuggestions for a word not present in the trie
[TestMethod]
public void TestGetSpellingSuggestions()
{
    // Arrange
    Trie trie = new Trie();
    trie.Insert("catastrophe");
    trie.Insert("catatonic");
    trie.Insert("caterpillar");

    // Act
    List<string> suggestions = trie.GetSpellingSuggestions("catatoinc");

    // Assert
    Assert.AreEqual(1, suggestions.Count, "Did not return all suggestions");
    Assert.IsTrue(suggestions.Contains("catatonic"), "Missing suggestion: catatonic");
}
public class TrieTest
{
    
}