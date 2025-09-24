# 📚 Kefir Project – FAQ Matching Web App

This project is a web application developed as part of a Bachelor's thesis. It demonstrates how user-submitted questions can be matched to existing FAQs using a simple word overlap algorithm. If no match is found, the question is stored for manual review and future answering.

---

## 🎯 Purpose

The goal of this project is to build an intelligent FAQ system that automatically responds to user questions by comparing them to stored FAQs. If a similar question is found, the corresponding answer is returned. Otherwise, the question is saved for an administrator to review and answer later.

---

## 🧠 How It Works

- Users submit a question via the web interface or API.
- The system splits the question into words and compares it to stored questions.
- A percentage match is calculated based on word overlap.
- If the match exceeds 50%, the corresponding answer is returned.
- If no match is found, the question is stored without an answer.

---

## 🔧 Technologies Used

- **Backend**: ASP.NET Web API (C#)
- **Frontend**: HTML, CSS, JavaScript
- **Database**: Entity Framework with SQL Server

---

## 🧪 Example Flow

1. User asks: “How does kefir work?”
2. System compares the question to stored FAQs using word overlap.
3. Match found with 60% similarity → Answer is returned.
4. No match above 50%? → Question is stored for admin review.

---

## 🔐 Roles & Permissions

- **User**: Submit questions
- **Administrator**: Edit answers, delete questions

---

⚠️ Note: The current implementation uses basic word matching. Cosine similarity is planned for future enhancement.

[Cosine similarity](SendQuestion.md)

---

- **Input Validation**  
  If the question is empty or consists only of whitespace, an error message is returned.

- **Database Query**  
  All FAQs that already have an answer are loaded.

- **Prepare Machine Learning**  
  - An ML context (`MLContext`) is created.  
  - The questions from the database are formatted for machine learning.

- **Text Vectorization with TF-IDF**  
  - The questions are converted into numerical vectors that reflect the meaning of the words.  
  - This is done using the TF-IDF method (Term Frequency-Inverse Document Frequency).

- **Vectorize New Question**  
  The new question is also transformed into a vector so it can be compared with existing ones.

- **Similarity Calculation**  
  - For each FAQ, the cosine similarity to the new question is calculated.  
  - The question with the highest similarity score is selected.

- **Decision Based on Similarity**  
  - If the similarity is below 0.8 or no matching question is found:  
    - The new question is saved in the database (without an answer).  
    - A message is returned indicating that no suitable answer was found.  
  - If a sufficiently similar question is found:  
    - The answer from that FAQ is returned.

📌 **Conclusion**  
This method uses machine learning to detect semantically similar questions and automatically provide appropriate answers. It's an intelligent FAQ mechanism that expands itself when needed.
