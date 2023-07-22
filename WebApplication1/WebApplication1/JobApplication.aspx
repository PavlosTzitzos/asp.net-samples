<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobApplication.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Apply here</h1>
            <p class="lead">Apply for a chance to win.</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="Form1">Form 1</h2>
                <p>
                    Please fill the form:
                    <form name="JobApplication">
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Email address</label>
                            <input type="email" class="form-control" id="exampleInputEmail1" placeholder="someone@example.com" aria-describedby="emailHelp" required="1">
                            <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
                        </div>
                        <select class="form-select" aria-label="Default select example">
                            <option selected>Choose how many kids</option>
                            <option value="1">One kid</option>
                            <option value="2">2 kids</option>
                            <option value="3">3 kids</option>
                            <option value="4">more than 3</option>
                        </select>
                        <div class="mb-3">
                            <label for="exampleInputFirstName" class="form-label">First Name</label>
                            <input type="text" class="form-control" id="exampleInputFirstName" placeholder="Pavlos" aria-describedby="nameHelp" required="1">
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputLastName" class="form-label">Last Name</label>
                            <input type="text" class="form-control" id="exampleInputLastName" placeholder="Tzitzos" aria-describedby="nameHelp" required="1">
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputPassword1" class="form-label">Password</label>
                            <input type="password" class="form-control" name="exampleInputPassword1" id="exampleInputPassword1" onblur="checkPassword()" required="1">
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputPassword2" class="form-label">Re-type Password</label>
                            <input type="password" class="form-control" name="exampleInputPassword2" id="exampleInputPassword2" onblur="checkPassword()" required="1">
                        </div>
                        <div class="mb-3">
                          <label for="formFileMultiple" class="form-label">Upload the prescription</label>
                          <input class="form-control" type="file" id="formFileMultiple" multiple>
                        </div>
                        <div class="mb-3 form-check">
                            <input type="checkbox" class="form-check-input" id="exampleCheck1" required="1">
                            <label class="form-check-label" for="exampleCheck1" onclick="checkPassword()">Agree to terms</label>
                        </div>
                            <button type="submit" class="btn btn-primary" onclick="/SubmitSuccessful"> submit</button> 
                        <span role="alert" id="nameError" aria-hidden="true">
                            Passwords do not match!
                        </span>
                    </form>
                </p>
            </section>
            <script language="Javascript" type="text/javascript">
                pass1 = ValidatorGetValue(exampleInputPassword1);
                pass2 = ValidatorGetValue(exampleInputPassword2);
                valid = ValidatorCompare(pass1, pass2, "NotEqual", str);
                if (valid) {

                }
            </script>
        </div>
    </main>

</asp:Content>
