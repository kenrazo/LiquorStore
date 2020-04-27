import React, { Component } from "react";
import { Container } from "reactstrap";
import { NavMenu } from "../NavMenu";
import Auxilary from "../../hoc/Auxilary";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <Auxilary>
        <NavMenu />
        <Container>{this.props.children}</Container>
      </Auxilary>
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
