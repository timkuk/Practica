import ApiService from "../../common/service/apiService";
import { EndpointsConstants } from "../../common/constants/endpointsConstants";

const AccountService = {
    login: (values: any) => ApiService.post(EndpointsConstants.Account.LOGIN, values),
    register: (values: any) => ApiService.post(EndpointsConstants.Account.REGISTER, values),
    getCurrentUser: () => ApiService.get(EndpointsConstants.Account.CURRENT_USER),
}

export default AccountService;