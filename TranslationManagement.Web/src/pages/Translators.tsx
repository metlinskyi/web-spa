import React, { useState }  from 'react';
import { getApiV1TranslatorsManagementGetTranslators } from '../api/services.gen';
import { TranslatorModel } from '../api';

function Translators() {
    const [loading, setLoading] = useState<boolean>(true);
    const [translators, setTranslators] = useState<TranslatorModel[]>();
    const onFetchTranslators = async () => {
      const translators = await getApiV1TranslatorsManagementGetTranslators();
      setTranslators(translators);
      setLoading(false)
    };
    if(loading)
      onFetchTranslators();
    return (
      <ul>
        {translators?.map(tr=>
          <li>{tr.name}</li>
        )}
      </ul>
    );
}

export default Translators;