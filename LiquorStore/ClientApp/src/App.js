import React, { Component } from "react";
import { Route, Switch, Router, Redirect } from "react-router";
import { Layout, LayoutLogin } from "./components/Layout/Layout";
import { Home } from "./containers/Home/Home";
import AddLiquor from "./containers/Liquor/AddLiquor";
import Login from "./containers/Login/Login";
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
          <AppLayoutRoute path="/add-liquor" component={AddLiquor} />
        </Switch>
      </Router>
    );
  }
}
