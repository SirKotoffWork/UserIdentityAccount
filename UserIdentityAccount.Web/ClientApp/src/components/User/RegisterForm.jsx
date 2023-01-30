import React, {useState} from 'react';
import { Button, Checkbox, Form, Input } from 'antd';

function RegisterForm(props) {
    const [inputName,setInputName] = useState('');
    const [inputPassword,setInputPassword] = useState('');
    const onFinish = (values) => {
    };


    async function getToken() {
        let UserData = {
            UserName:inputName,
            password:inputPassword
        }
        const response = await fetch(
            'https://localhost:7140/api/User/Authenticate',
            {
                method: 'POST',
                headers: {
                   // 'Access-Control-Allow-Origin':'*',
                   // 'Access-Control-Allow-Headers':'*',
                  //  'Accept':  '*/*, text/plain', //'application/json, text/plain,
                   //'Content-Type': 'text/plain; charset=utf-8'
                    'Accept': 'application/json, text/plain, */*',
                   // 'Content-Type': 'application/json'
                },
                body:JSON.stringify(UserData)
            }
        );
        console.log(response.body)
    }
    
    const onFinishFailed = (errorInfo) => {
    };
    return (
        <Form
            name="basic"
            labelCol={{span: 8,}} wrapperCol={{span: 16,}} style={{maxWidth: 600,}} initialValues={{remember: true,}} onFinish={onFinish} onFinishFailed={onFinishFailed} autoComplete="off">
            <Form.Item
                label="Username"
                name="username"
                value={inputName}
                onChange={(event) => setInputName(event.target.value)}
                rules={[
                    {
                        required: true,
                        message: 'Please input your username!',
                    },
                ]}
            >
                <Input />
            </Form.Item>

            <Form.Item
                label="Password"
                name="password"
                value={inputPassword}
                onChange={(event) => setInputPassword(event.target.value)}
                rules={[
                    {
                        required: true,
                        message: 'Please input your password!',
                    },
                ]}
            >
                <Input.Password />
            </Form.Item>
            

            <Form.Item
                wrapperCol={{
                    offset: 8,
                    span: 16,
                }}
            >
                <Button type="primary" htmlType="submit" onClick={getToken}>
                    Register
                </Button>
            </Form.Item>
        </Form>
    );
}
export default RegisterForm;