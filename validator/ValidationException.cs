using System;
using System.Collections.Generic;
using System.Text;

namespace Contest_CS.validator
{
    public class ValidationException : SystemException{

    List<String> errors =  new List<String>();

    public ValidationException(){

    }

    public ValidationException(String message){
        errors.Add(message);
    }

    public ValidationException(List<String> errors){
        this.errors = errors;
    }

    public String getErrors(){
        StringBuilder errors = new StringBuilder();
        foreach(String error in this.errors){
            errors.Append(error).Append("\n");
        }
        return errors.ToString();
    }

}

}