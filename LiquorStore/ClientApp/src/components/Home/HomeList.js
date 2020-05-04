import React from "react";
import ToolkitProvider, { Search } from "react-bootstrap-table2-toolkit";
import { Breadcrumb, BreadcrumbItem } from "reactstrap";
import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";

const { SearchBar } = Search;
const RemoteTable = ({
  columns,
  keyField,
  data,
  page,
  sizePerPage,
  onTableChange,
  totalSize,
}) => (
  <div>
    <ToolkitProvider keyField={keyField} data={data} columns={columns} search>
      {(props) => (
        <div>
          <SearchBar {...props.searchProps} />
          <BootstrapTable
            {...props.baseProps}
            remote
            onTableChange={onTableChange}
            pagination={paginationFactory({ page, sizePerPage, totalSize })}
            striped
            hover
            condensed
            noDataIndication="No records found"
          />
        </div>
      )}
    </ToolkitProvider>
  </div>
);
const columns = [
  {
    dataField: "liquorId",
    text: "Liquor ID",
    sort: true,
  },
  {
    dataField: "liquorName",
    text: "Liquor Name",
    sort: true,
  },
  {
    dataField: "liquorType",
    text: "Liquor Type",
    sort: true,
  },
];
const homeList = (props) => (
  <div>
    <Breadcrumb tag="nav" listTag="div">
      <BreadcrumbItem active tag="span">
        Liquors
      </BreadcrumbItem>
    </Breadcrumb>
    <h1>Liquors</h1>
    <br />
    <RemoteTable
      columns={columns}
      keyField="liquorId"
      data={props.liquors}
      page={props.pageNumber}
      sizePerPage={props.sizePerPage}
      totalSize={props.totalSize}
      onTableChange={props.handleTableChange}
    />
  </div>
);

export default homeList;
