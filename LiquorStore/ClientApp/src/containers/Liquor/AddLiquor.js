import React, { Component } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import LiquorService from "../../services/liquor-service";

class AddLiquor extends Component {
  state = {
    liquorName: "",
    liquorTypeId: 0,
  };

  handleOnChange = (property, e) => {
    this.setState({ [property]: e.target.value });
  };

  handleSubmit = () => {
    LiquorService.addLiquor(
      this.state.liquorName,
      this.state.liquorTypeId
    ).then((data) => {
      console.log(data);
      if (data.status === 201) {
        alert("inserted");
      } else {
        alert("error");
      }
    });
  };

  render() {
    return (
      <div>
        <h1>Add Liquor</h1>
        <Form>
          <Form.Group>
            <Form.Label>Liquor name</Form.Label>
            <Form.Control
              value={this.state.liquorName}
              onChange={this.handleOnChange.bind(this, "liquorName")}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Liquor Type</Form.Label>
            <Form.Control
              as="select"
              value={this.state.liquorTypeId}
              onChange={this.handleOnChange.bind(this, "liquorTypeId")}
            >
              <option>1</option>
              <option>2</option>
              <option>3</option>
              <option>4</option>
              <option>5</option>
            </Form.Control>
          </Form.Group>
          <Button variant="primary" onClick={this.handleSubmit}>
            Submit
          </Button>
        </Form>
      </div>
    );
  }
}

export default AddLiquor;
