import React, {useEffect, useState} from 'react';
import {Table} from "antd";

function DataTable(props) {
    const [dataTable,setDataTable] = useState([]);
    const columns = [
        {
            title: 'Name',
            dataIndex: 'name',
            width: 150,
        },
    ];
    const data = [];
    async function getDataTable(){

        fetch('https://localhost:7140/api/Data/GetTable', {
            method: 'GET',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
        }).then(res => res.json())
            .then(res => {
                setDataTable(res);
                data.push(res)
                console.log(res);
            });
       console.log(data.length)
        
        // const response = await fetch(
        //     'https://localhost:7140/api/Data/GetTable',
        //     {
        //         method: 'GET',
        //         headers: {
        //             // 'Access-Control-Allow-Origin':'*',
        //             // 'Access-Control-Allow-Headers':'*',
        //              'Accept': '*/*',
        //             //'Content-Type': 'application/json'
        //         },
        //        
        //     }
        // );
        // setDataTable(response.body)
        // console.log(response.body);
    }
    
    return (
        <div>
            <button onClick={getDataTable}>wef</button>
            <Table
                columns={columns}
                dataSource={data}
                pagination={{
                    pageSize: 50,
                }}
                scroll={{
                    y: 240,
                }}
            />
        </div>
    );
}

export default DataTable;