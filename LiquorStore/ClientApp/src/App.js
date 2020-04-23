import React, { Component } from "react";
import { Route, Switch, Router, Redirect } from "react-router";
import { Layout, LayoutLogin } from "./components/Layout";
import { Home } from "./components/Home";
import Login from "./components/Login/Login";
import history from "./history";
import "./custom.css";

const LoginLayoutRoute = ({ component: Component, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(matchProps) => (
        <LayoutLogin>
          <Component {...matchProps} />
        </LayoutLogin>
      )}
    />
  );
};

const AppLayoutRoute = ({ component: Component, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(matchProps) =>
        localStorage.getItem("isLoggedIn") ? (
          <Layout>
            <Component {...matchProps} />
          </Layout>
        ) : (
          <Redirect
            to={{
              pathname: "/sign-in",
              state: { from: matchProps.location },
            }}
          />
        )
      }
    />
  );
};

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Router history={history}>
        <Switch>
          <LoginLayoutRoute path="/sign-in" component={Login} />
          <AppLayoutRoute exact path="/" component={Home} />
        </Switch>
      </Router>
    );
  }
}
