import React, { Component } from "react";
import { Container } from "reactstrap";
import { NavMenu } from "./NavMenu";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <NavMenu />
        <Container>{this.props.children}</Container>
      </div>
    );
  }
}

export class LayoutLogin extends Component {
  static displayName = LayoutLogin.name;

  render() {
    return (
      <div>
        <Container>{this.props.children}</Container>
      </div>
    );
  }
}
