import React from "react";
import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";
import ToolkitProvider, { Search } from "react-bootstrap-table2-toolkit";

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

const homeList = (props) => (
  <div>
    <li>
      <ul>asd</ul>
      <ul>zxc</ul>
    </li>
    <li>
      <ul>asd</ul>
      <ul>zxc</ul>
    </li>
  </div>
);

export default homeList;
