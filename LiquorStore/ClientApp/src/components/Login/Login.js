import React, { Component } from "react";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import UserService from "../../services/user-service";

class Login extends Component {
  loginHandler = () => {
    console.log("asd");
    UserService.authenticate("asd", "zxc").then((data) => {
      if (data.status === 200) {
        //    localStorage.setItem("isLoggedIn", true);
        //   history.push("/");
      } else {
        //   localStorage.removeItem("isLoggedIn");
        // this.setState(() => ({
        //    password: "",
        //    alert: {
        //     isOpen: true,
        //     isSuccess: false,
        //     message: "Your email or password is incorrect",
        //  },
        // }));
      }
    });
  };
  render() {
    return (
      <div>
        <TextField id="standard-basic" label="Username" />
        <br></br>
        <TextField id="standard-basic" label="Password" />
        <br></br>
        <br></br>
        <Button variant="contained" color="primary" onClick={this.loginHandler}>
          Submit
        </Button>
      </div>
    );
  }
}

export default Login;
