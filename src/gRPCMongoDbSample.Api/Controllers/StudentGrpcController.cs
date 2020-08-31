using AutoMapper;
using Grpc.Core;
using gRPCMongoDbSample.Api.DataAccess;
using gRPCMongoDbSample.Api.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCMongoDbSample.Api.Controllers
{
    public class StudentGrpcController : Protos.StudentService.StudentServiceBase
    {
        private readonly StudentDataAccess _students;
        private readonly IMapper _mapper;

        public StudentGrpcController(StudentDataAccess students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;
        }

        public override async Task<GetStudentResponse> GetStudent(GetStudentRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var student = await _students.GetByIdWithCoursesAsync(request.Id);
                    return new GetStudentResponse
                    {
                        Student = _mapper.Map<Student>(student)
                    };
                }
                else
                {
                    return new GetStudentResponse
                    {
                        Error = "ID is null or empty"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetStudentResponse
                {
                    Error = $"{ex.Message}"
                };
            }
        }
    }
}
