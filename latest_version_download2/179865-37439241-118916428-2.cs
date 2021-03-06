    public ActionResult GetAnswer(List<PossibleAnswerVM> possibleAnswers)
    {
        if (IsLastQuestion(possibleAnswers.FirstOrDefault().IdQuestion))
        {
              IEnumerable<Anketa> anketas = Manager.SelectAnketa();
              return View("VIEWNAME", anketas);
        }
        return null;
    }
    private static bool IsLastQuestion(int idQuestion)
    {
        var returnValue = false;
        
        Question question = Manager.GetQuestion(idQuestion);
        List<Question> questions = Manager.SelectQuestions(question.idAnketa);
                    
        if (questions.Count == Manager.GetCountQuestionsAnswered(question.idAnketa, SessionUser.PersonID))
        {
            returnValue = true;
        }                      
        return returnValue;
    }
