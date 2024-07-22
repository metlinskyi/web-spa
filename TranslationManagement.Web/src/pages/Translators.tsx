import React, { useEffect, useState }  from 'react';
import { 
  getApiV1TranslatorsManagementGetTranslators,
  getApiV1TranslatorsManagementGetTranslatorsByName,
  postApiV1TranslatorsManagementAddTranslator,
  postApiV1TranslatorsManagementUpdateTranslatorStatus
} from '../api/services.gen';
import { TranslatorModel } from '../api';
import { Spinner, Table, Form, Button, InputGroup } from 'react-bootstrap';
import { isNullishCoalesce } from 'typescript';

function Translators() {
    const statuses = ["Applicant","Certified", "Deleted"];
    const [loading, setLoading] = useState<boolean>(true);
    const [translators, setTranslators] = useState<TranslatorModel[]>([]);
    const [translator, setTranslator] = useState<TranslatorModel>({ } as TranslatorModel);
    const onFetchTranslators = async () => {
      setLoading(true);
      const translators = await getApiV1TranslatorsManagementGetTranslators();
      setTranslators(translators);
      setLoading(false)
    };
    const onFetchTranslatorsByName = async (value:string) => {
      setLoading(true);
      const translators = await getApiV1TranslatorsManagementGetTranslatorsByName({name:value});
      setTranslators(translators);
      setLoading(false)
    };
    const onFetchAddTranslator = async (value:TranslatorModel) => {
      const result = await postApiV1TranslatorsManagementAddTranslator({requestBody:value});
    };
    const onFetchUpdateTranslatorStatus = async (translatorId:string, status:string) => {
      const result = await postApiV1TranslatorsManagementUpdateTranslatorStatus({newStatus:status, translatorId: translatorId});
    };
    useEffect(()=>{
      onFetchTranslators()
    }, []) 
    return (
      <Table>
        <thead>
          <tr>
            <th className="d-flex flex-row">
              <label className='p-2'>Name</label>
              <Form.Control className='p-2' width={30} size="sm" type="text" placeholder="Search" 
                  onChange={ (event) => { 
                    event.target.value.length > 0 
                      ? onFetchTranslatorsByName(event.target.value) 
                      : onFetchTranslators();
                  } }/>
            </th>
            <th>Status</th>
            <th>Hourly Rate</th>
            <th>Credit Card Number</th>
            <th></th>
          </tr>
        </thead>
        {loading
          ?
            <tbody>    
                <tr>
                  <td colSpan={5}>
                  <Spinner animation="border" role="status">
                    <span className="visually-hidden">Loading...</span>
                  </Spinner>
                  </td>
                </tr>
            </tbody>
          :  
            <tbody>    
              {translators?.map(tr=>
                <tr id={tr.id || ""} >
                  <td>{tr.name}</td>
                  <td>
                      <Form.Select size='sm' id={tr.id || ""}  
                        onChange={ (event) => { 
                            onFetchUpdateTranslatorStatus(event.target.id, event.target.value);
                        }}>
                        {
                          statuses.map(s=><option value={s} selected={s==tr.status ? true : false}>{s}</option>)
                        }
                      </Form.Select>    
                  </td>
                  <td>{tr.hourlyRate}</td>
                  <td>{tr.creditCardNumber}</td>
                  <td></td>
                </tr>
              )}
            </tbody>
        }
        <tfoot>
          <tr>
            <td>
                <Form.Control size="sm" type="text" placeholder="Name" name="Name" required
                  onChange={ (event) => { translator.name = event.target.value } } />
            </td>
            <td>
              <Form.Select size='sm'
                onChange={ (event) => { translator.status = event.target.value }}>
                {
                  statuses.filter(s=>s!="Deleted").map(s=><option value={s}>{s}</option>)
                }
              </Form.Select>
            </td>
            <td>
              <Form.Control size="sm" type="text" placeholder="Hourly Rate" required
                onChange={ (event) => { translator.hourlyRate = event.target.value } } />
            </td>
            <td>
              <Form.Control size="sm" type="text" placeholder="Credit Card Number" required
                onChange={ (event) => { translator.creditCardNumber = event.target.value } }  />
            </td>
            <td>
              <Button variant="primary" size="sm"
                onClick={
                  (event) => {
                      onFetchAddTranslator(translator);
                      translators.push(translator);
                      setTranslator({ } as TranslatorModel);
                  }
                }>+</Button>
            </td>
          </tr>
        </tfoot>
      </Table>
    );
}
export default Translators;