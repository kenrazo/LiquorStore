import React, { Component } from "react";
import TextField from "@material-ui/core/TextField";
import { Button } from "reactstrap";
import UserService from "../../services/user-service";
import history from "../../history";

class Login extends Component {
  state = {
    username: "",
    password: "",
  };

  handleOnChange(property, e) {
    this.setState({ [property]: e.target.value });
  }

  loginHandler = () => {
    console.log("asd");
    UserService.authenticate(this.state.username, this.state.password).then(
      (data) => {
        if (data.status === 200) {
          localStorage.setItem("isLoggedIn", true);
          history.push("/");
        } else {
          localStorage.removeItem("isLoggedIn");
          this.setState(() => ({
            password: "",
          }));
        }
      }
    );
  };
  render() {
    return (
      <div>
        <TextField
          required
          id="standard-basic"
          label="Username"
          value={this.state.username}
          onChange={this.handleOnChange.bind(this, "username")}
        />
        <br></br>
        <TextField
          required
          id="standard-basic"
          label="Password"
          value={this.state.password}
          onChange={this.handleOnChange.bind(this, "password")}
        />
        <br></br>
        <br></br>
        <Button
          className="btn btn-primary btn-block"
          onClick={this.loginHandler}
        >
          Submit
        </Button>
      </div>
    );
  }
}

export default Login;
