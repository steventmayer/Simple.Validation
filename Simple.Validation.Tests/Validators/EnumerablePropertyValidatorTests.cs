﻿using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using NUnit.Framework;
using Personnel.Sample;
using Personnel.Sample.Comparers;
using Personnel.Sample.Validators;

namespace Simple.Validation.Tests.Validators
{
    [TestFixture]
    public class EnumerablePropertyValidatorTests
    {
        [Test]
        public void Required()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required();

            // Act
            var results = validator.Validate(new Employee()
                                                 {
                                                     ContactInfo = null,
                                                 });

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Severity, Is.EqualTo(ValidationResultSeverity.Error));
        }

        [Test]
        public void Size_Minimum_NotRequired_ValueNotSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Size(1)
                ;

            // Act
            var results = validator.Validate(new Employee()
                                                 {
                                                     ContactInfo = null,
                                                 });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Size_Minimum_NotRequired_InvalidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Size(1)
                ;

            // Act
            var results = validator.Validate(new Employee()
                                                 {
                                                     ContactInfo = new List<ContactInfo>(),
                                                 });

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Severity, Is.EqualTo(ValidationResultSeverity.Error));
        }

        [Test]
        public void Size_Minimum_Required_InvalidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Size(1)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>(),
            });

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Severity, Is.EqualTo(ValidationResultSeverity.Error));
        }

        [Test]
        public void Size_Minimum_NotRequired_ValidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Size(1)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>()
                                  {
                                      new ContactInfo()
                                  },
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Size_Minimum_Required_ValidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Size(1)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>()
                                  {
                                      new ContactInfo()
                                  },
            });

            // Assert
            Assert.That(results, Is.Empty);
        }




        [Test]
        public void Size_Maximum_NotRequired_ValueNotSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Size(1, 2)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = null,
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Size_Maximum_NotRequired_InvalidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Size(1, 2)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>()
                                  {
                                      new ContactInfo(),
                                      new ContactInfo(),
                                      new ContactInfo(),
                                  },
            });

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Severity, Is.EqualTo(ValidationResultSeverity.Error));
        }

        [Test]
        public void Size_Maximum_Required_InvalidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Size(1, 2)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>()
                                  {
                                      new ContactInfo(),
                                      new ContactInfo(),
                                      new ContactInfo(),
                                  },
            });

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Severity, Is.EqualTo(ValidationResultSeverity.Error));
        }

        [Test]
        public void Size_Maximum_NotRequired_ValidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Size(1, 2)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>()
                                  {
                                      new ContactInfo(),
                                      new ContactInfo(),
                                  },
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Size_Maximum_Required_ValidValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Size(1, 2)
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>()
                                  {
                                      new ContactInfo(),
                                      new ContactInfo(),
                                  },
            });

            // Assert
            Assert.That(results, Is.Empty);
        }



        [Test]
        public void Unique_NotRequired_ValueNotSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Unique()
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = null,
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Unique_Required_EmptyValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique()
                ;

            // Act
            var results = validator.Validate(new Employee()
            {
                ContactInfo = new List<ContactInfo>(),
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Unique_SingleValueSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique()
                ;

            // Act
            var contactInfo = Builder<ContactInfo>.CreateListOfSize(1).Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Unique_TwoValuesSpecified()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique()
                ;

            // Act
            var contactInfo = Builder<ContactInfo>.CreateListOfSize(2).Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Unique_SameValueSpecifiedTwice()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique()
                ;

            // Act
            var contactInfo = Builder<ContactInfo>.CreateListOfSize(1).Build();
            contactInfo.Add(contactInfo.First());
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            });

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Unique_ValidValues_CustomEqualityComparer()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique(new ContactInfoTypeEqualityComparer())
                ;

            // Act
            var contactInfo = Builder<ContactInfo>.CreateListOfSize(2).Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Unique_InvalidValues_CustomEqualityComparer()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique(new ContactInfoTypeEqualityComparer())
                ;

            // Act
            var contactInfo = Builder<ContactInfo>
                .CreateListOfSize(2)
                .All().Do(c => c.Type = "Email")
                .Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            }).ToList();

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Unique_ValidValues_ByPredicate()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique<ContactInfo>((left, right) => left.Type == right.Type)
                ;

            // Act
            var contactInfo = Builder<ContactInfo>.CreateListOfSize(2).Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Unique_InvalidValues_ByPredicate()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique<ContactInfo>((left, right) => left.Type == right.Type)
                ;

            // Act
            var contactInfo = Builder<ContactInfo>
                .CreateListOfSize(2)
                .All().Do(c => c.Type = "Email")
                .Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            }).ToList();

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Unique_ValidValues_BySelector()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique<ContactInfo>(c => c.Type)
                ;

            // Act
            var contactInfo = Builder<ContactInfo>.CreateListOfSize(2).Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            });

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Unique_InvalidValues_BySelector()
        {
            // Arrange
            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Required()
                .Unique<ContactInfo>(c => c.Type)
                ;

            // Act
            var contactInfo = Builder<ContactInfo>
                .CreateListOfSize(2)
                .All().Do(c => c.Type = "Email")
                .Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            }).ToList();

            // Assert
            Assert.That(results, Is.Not.Empty);
            var result = results.First(vr => vr.PropertyName == "ContactInfo");
            Assert.That(result, Is.Not.Null);
        }


        [Test]
        public void Cascade_ValidValues()
        {
            // Arrange
            var validatorProvider = new DefaultValidatorProvider();
            validatorProvider.RegisterValidator(new SaveContactInfoValidator());
            Validator.SetValidatorProvider(validatorProvider);

            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Cascade("Save")
                ;

            // Act
            var contactInfo = Builder<ContactInfo>
                .CreateListOfSize(2)
                .All().Do(c => c.Type = "Email")
                .Build();
            var results = validator.Validate(new Employee()
            {
                ContactInfo = contactInfo,
            }).ToList();

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Cascade_InValidValues()
        {
            // Arrange
            var validatorProvider = new DefaultValidatorProvider();
            validatorProvider.RegisterValidator(new SaveContactInfoValidator());
            Validator.SetValidatorProvider(validatorProvider);

            var validator = Properties<Employee>
                .For(e => e.ContactInfo)
                .Cascade("Save")
                ;

            // Act
            var contactInfo = Builder<ContactInfo>
                .CreateListOfSize(2)
                .All().Do(c =>
                              {
                                  c.Type = "Email";
                                  c.Text = string.Empty;
                              })
                .Build();
            var employee = new Employee()
                               {
                                   ContactInfo = contactInfo,
                               };
            var results = validator.Validate(employee).ToList();

            // Assert
            Assert.That(results, Is.Not.Empty);
            for (var i = 0; i < contactInfo.Count; i++)
            {
                var expectedPropertyName = string.Format("ContactInfo[{0}].Text", i);
                var expectedResults = results.Where(vr => vr.PropertyName == expectedPropertyName).ToList();
                Assert.That(expectedResults, Is.Not.Empty);

                foreach (var expectedResult in expectedResults)
                {
                    Assert.That(expectedResult.Context == employee);
                }
            }
        }
    }
}