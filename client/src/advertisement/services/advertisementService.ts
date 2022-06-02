import ApiService from "../../common/service/apiService";
import { EndpointsConstants } from "../../common/constants/endpointsConstants";

const AdvertisementService = {
    fetchAdvertisements: (params: URLSearchParams) => ApiService.get(EndpointsConstants.Advertisements.GET, params),
    fetchAdvertisementDetails: (id: string) => ApiService.get(`${EndpointsConstants.Advertisements.GET}/${id}`),
    fetchAdvertisementFilters: () => ApiService.get(EndpointsConstants.Filters.FILTERS)
}
export default AdvertisementService;